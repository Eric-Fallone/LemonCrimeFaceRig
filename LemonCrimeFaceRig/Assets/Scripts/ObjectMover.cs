using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
	Camera cam;

	private bool isMoving = false;
	private Vector3 targetPosition;

	private float targetX, targetY;
    // Start is called before the first frame update
    void Start()
    {
		cam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
		if(isMoving == true)
		{
			targetPosition = cam.ScreenToWorldPoint(new Vector3(targetX, targetY, 20));
			this.transform.position = targetPosition;
			isMoving = false;
		}
	}

	public void MoveObjectTowardsLocation( float x, float y )
	{
		targetX = x;
		targetY = y;
		isMoving = true;
		
	}

}
