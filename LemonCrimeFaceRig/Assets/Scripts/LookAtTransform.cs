using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour
{
	public Transform target;
	Vector3 startingPosition;

	public Vector2 MaximumAngles = new Vector2(30, 30);

	public float power = 1;

	public float MuckTime = 5;
	private float CurrentMuckTime;
	public Vector2 MuckAngles = new Vector2(30, 30);

	private bool isMucking = false;
	private void Start()
	{
		startingPosition = this.transform.localEulerAngles;

	}
	// Update is called once per frame
	void Update()
	{
		Vector3 temp = startingPosition;


		temp.x = temp.x + (Mathf.Clamp(((target.localPosition.y - this.transform.position.y ) * power ), -1 * MaximumAngles.y, MaximumAngles.y));

		temp.y = temp.y + (Mathf.Clamp(((target.localPosition.x - this.transform.position.x) * power ), -1 * MaximumAngles.x, MaximumAngles.x));

		CurrentMuckTime -= Time.deltaTime;
		if (CurrentMuckTime > 0)
		{ 
			temp.x = startingPosition.x + MuckAngles.x;
			temp.y = startingPosition.y + MuckAngles.y;
		}

		this.transform.localEulerAngles = temp;
	}

	public void MuckMuck()
	{
		CurrentMuckTime = MuckTime;
		isMucking = true;
	}

}
