using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConrolBone : MonoBehaviour
{
	public Transform[] listOBones;

	Vector3[] startingPostions;

	public float RotatePower;

	public void Start()
	{
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
			temp.z = temp.z + RotatePower;
			listOBones[i].transform.localEulerAngles = temp;
		}
	}
}
