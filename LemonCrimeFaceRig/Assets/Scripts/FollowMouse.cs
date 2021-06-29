using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

	Camera cam;
	private Vector3 mousePosition;
	private Vector3 targetPosition;
	public float moveSpeed = 0.1f;

	void Start()
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
			mousePosition = Input.mousePosition;
			//mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			targetPosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -10));
			this.transform.position = targetPosition;
	}
}