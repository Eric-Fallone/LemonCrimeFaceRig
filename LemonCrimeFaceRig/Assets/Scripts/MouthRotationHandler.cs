using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthRotationHandler: MonoBehaviour
{
	public BlendtreeLandMarkHandler BlendHandler;

	public Transform TransformToMove;

	public Vector3 StartAngles;

	public Vector3 ClosedMouthAngle, nuetralMouthAngle, openMouthAngle;
	public float nuetralMouth;
	

	private void Start()
	{
		//BlendHandler.g
	}
	// Update is called once per frame
	void Update()
	{
		//result = Vector3.forward * 5;
		if (BlendHandler.getDistanceValue() < nuetralMouth)
		{
			TransformToMove.rotation = Quaternion.Euler(x: StartAngles.x + ClosedMouthAngle.x, y: StartAngles.y + ClosedMouthAngle.y, z: StartAngles.z + ClosedMouthAngle.z );// * result ;
		}
		if (BlendHandler.getDistanceValue() >= nuetralMouth)
		{
			TransformToMove.rotation = Quaternion.Euler(x: StartAngles.x + openMouthAngle.x, y: StartAngles.y + openMouthAngle.y, z: StartAngles.z + openMouthAngle.z );// * result ;
		}

		//TransformToMove.LookAt(lookAtTran, Vector3.forward);

		//TransformToMove.rotation ;
		//TransformToMove.(TransformToMove.position, transform.forward, AngleToMoveTo);
	}
}