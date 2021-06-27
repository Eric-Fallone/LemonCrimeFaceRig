using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObjectRotator : MonoBehaviour
{
	public BlendtreeLandMarkHandler BlendHandler;

	public Transform TransformToMove;

	public float AngleToMoveTo;

	public Vector3 StartAngles;
	public float rotation;

	public Transform lookAtTran;

	private void Start()
	{
		//BlendHandler.g
	}
	// Update is called once per frame
	void Update()
	{
		//result = Vector3.forward * 5;

		TransformToMove.rotation = Quaternion.Euler(x: StartAngles.x, y: -StartAngles.y, z: StartAngles.z + BlendHandler.getAngleValue() );// * result ;

		//TransformToMove.LookAt(lookAtTran, Vector3.forward);

		//TransformToMove.rotation ;
		//TransformToMove.(TransformToMove.position, transform.forward, AngleToMoveTo);
	}
}