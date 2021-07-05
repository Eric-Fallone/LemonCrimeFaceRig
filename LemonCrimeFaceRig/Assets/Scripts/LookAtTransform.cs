using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour
{
	public Transform target;
	Vector3 startingPosition;

	public float x, y;

	public float screenX, ScreenY;

	public Vector2 MaximumAngles = new Vector2(30, 30);

	public float power = 1;

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
	

		this.transform.localEulerAngles = temp;
	}
}
