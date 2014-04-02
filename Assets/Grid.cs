﻿using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

	[Popup ("Warrior", "Mage", "Archer", "Ninja")]
	public string @class = "Warrior";

	public float width  = 32f;
	public float height = 32f;

	[MinMaxRange(0f, 100f)]
	public Vector2 explosionRange = new Vector2(10f, 90f);
	//[Compact]
	public Vector2 age;

	void Start ()
	{
		@class = "aa";
	}

	void Update ()
	{

	}

//	void OnDrawGizmos()
//	{
//		Vector3 pos = Camera.current.transform.position;
//
//		for (float y = pos.y - 800.0f; y < pos.y + 800.0f; y+= height)
//		{
//			Gizmos.DrawLine(new Vector3(-1000000.0f, Mathf.Floor(y/height) * height, 0.0f),
//			                new Vector3(1000000.0f, Mathf.Floor(y/height) * height, 0.0f));
//		}
//		
//		for (float x = pos.x - 1200.0f; x < pos.x + 1200.0f; x+= width)
//		{
//			Gizmos.DrawLine(new Vector3(Mathf.Floor(x/width) * width, -1000000.0f, 0.0f),
//			                new Vector3(Mathf.Floor(x/width) * width, 1000000.0f, 0.0f));
//		}
//	}
}
