using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBoneLemonCrime : MonoBehaviour
{
	public Transform[] listOBones;
	public BlendtreeLandMarkHandler[] listOLandmarkHandlers;
	public float[] RotateMultipliers;
	public float[] StartingOffset;
	public BlendtreeLandMarkHandler scaleLandMarkHandler;
	public float[] scaleMultiplier;
	Vector3[] startingPostions;

	public void Start()
	{
		if(listOBones.Length != RotateMultipliers.Length && listOBones.Length != listOLandmarkHandlers.Length && listOBones.Length != listOLandmarkHandlers.Length)
		{
			Debug.LogError(this.name + ": Invalid length of RotateMultiplier Array" );
		}

		startingPostions = new Vector3[listOBones.Length];

		for (int i = 0; i < listOBones.Length; i++)
		{
			startingPostions[i] = listOBones[i].transform.localEulerAngles;
		}
	}

	public void Update()
	{
		ChangeAnglesOfBones();
	}

	public void ChangeAnglesOfBones()
	{
		for (int i = 0; i < listOBones.Length; i++)
		{
			Vector3 temp = startingPostions[i];

			temp.z = temp.z + StartingOffset[i] + ( (RotateMultipliers[i] * listOLandmarkHandlers[i].getDistanceValue() ) ) ;

			if(scaleLandMarkHandler != null)
			{
				temp.x = temp.x + scaleLandMarkHandler.getDistanceValue() * scaleMultiplier[i];
			}

			listOBones[i].transform.localEulerAngles = temp;
		}
	}
}
