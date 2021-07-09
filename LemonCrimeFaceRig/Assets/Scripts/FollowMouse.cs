using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	public float offSetFromMainCamera;

	Camera cam;
	private Vector3 mousePosition;
	private Vector3 targetPosition;

	public bool StopMovingOnCLick = false;


	void Start()
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		mousePosition = Input.mousePosition;
		//mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		targetPosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, offSetFromMainCamera));
		this.transform.position = targetPosition;

		if (StopMovingOnCLick == true && Input.GetMouseButtonDown(0) == true)
		{
			this.enabled = false;
			Saver.S.SaveLocation(this.gameObject);
		}
	}
}