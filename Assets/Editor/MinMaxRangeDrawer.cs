using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
class MinMaxRangeDrawer : PropertyDrawer 
{
	Vector2 tempMinMax;
	// 16 is the default height of a propery
	float textHeight = 16f;
	float sliderHeight = 16f;

	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) {
			// 16 + sliderHeight
		return base.GetPropertyHeight (prop, label) + sliderHeight;
	}

	// Draw the property inside the given rect
	override public void OnGUI (Rect position, SerializedProperty property,  GUIContent label) {

		// First get the attribute since it contains the range for the slider
		MinMaxRangeAttribute range = attribute as MinMaxRangeAttribute;
		Rect defaultRect = position;
		// Now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
		if (property.propertyType == SerializedPropertyType.Vector2)
		{
			tempMinMax = property.vector2Value;

			// BeginProperty and EndProperty automatically handle default labels, bold font for prefab overrides, 
			// revert to prefab right click menu, and setting showMixedValue to true if the values of the property are different when multi-object editing.
			label = EditorGUI.BeginProperty (position, label, property);

			EditorGUI.BeginChangeCheck();

			position.height = textHeight;

			tempMinMax = EditorGUI.Vector2Field(position, label, tempMinMax);

			position = EditorGUI.IndentedRect(defaultRect);
			position.y += textHeight;
			position.height = sliderHeight;

			EditorGUI.MinMaxSlider(new GUIContent("Slider"), position,ref tempMinMax.x, ref tempMinMax.y, range.min, range.max);

			// Only assign the value back if it was actually changed by the user.
			// Otherwise a single value will be assigned to all objects when multi-object editing,
			// even when the user didn't touch the control.
			if(EditorGUI.EndChangeCheck())
			{
				property.vector2Value = tempMinMax;
			}

			EditorGUI.EndProperty();
		}
		else
		{
			EditorGUI.LabelField (position, label.text, "Use MinMaxRange with Vector2.");
		}
	}


}