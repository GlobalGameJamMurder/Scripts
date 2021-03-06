﻿using UnityEngine;
using System.Collections;

public class ClickDrag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float dragSpeed = 10;
	private Vector3 dragOrigin;
	
	
	void Update()
	{
		camera.orthographicSize = Mathf.Clamp(camera.orthographicSize + (Input.mouseScrollDelta.y ), 300,700) ;

		if (Input.GetMouseButtonDown(1))
		{
			dragOrigin = Input.mousePosition;
			return;
		}
		
		if (!Input.GetMouseButton(1)) return;

		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(-pos.x * dragSpeed, -pos.y * dragSpeed, 0);
		
		transform.Translate(move, Space.World);  

	}
}
