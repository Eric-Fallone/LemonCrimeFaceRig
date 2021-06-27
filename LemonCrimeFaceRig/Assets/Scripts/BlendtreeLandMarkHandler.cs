using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[CreateAssetMenu(fileName = "Blend Tree Land Mark Handler", menuName = "ScriptableObjects/BlendtreeLandMarkHandler")]
public class BlendtreeLandMarkHandler : ScriptableObject
{
	public bool DebugPrint = false;
	public int[] IndexesOfLandMarks;

	[SerializeField]
	private float BlendValue;
	[SerializeField]
	private float BlendValueAngle;

	public float min;
	public float max;
	[SerializeField]
	private bool InitialCalibration = false;



	public void OnEnable()
	{
		if (min == max)
		{
			Debug.LogWarning("MIN AND MAX OF "+ this.name + " ARE THE SAME" );
		}
	}

	public int[] getIndexes()
	{
		return IndexesOfLandMarks;
	}

	public void SetLandMarks(float x1, float y1, float x2, float y2)
	{
		Vector2 first = new Vector2(x1, y1);
		Vector2 second = new Vector2(x2, y2);

		float distance = Mathf.Clamp( Vector2.Distance(first, second), min, max );
		float value = (distance ) / (max - min);
		if (DebugPrint)
		{
			Debug.Log("Distance: " + distance + " Value: " + value);
		}
		BlendValue = Mathf.Clamp(value, 0, 1);


		float sign = (second.y < first.y) ? -1.0f : 1.0f;
		BlendValueAngle = Vector2.Angle( LandMarkInfoProcesser.S.FaceAngle , (second - first)) *sign ;

	}

	public void StartCalibrating()
	{
		InitialCalibration = true;
	}

	public void Calibrate(float x1, float y1, float x2, float y2)
	{
		float distance = Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2));
		//Debug.Log(distance);
		if (distance > max || InitialCalibration == true)
		{
			max = distance;
		}
		if (distance < min || InitialCalibration == true)
		{
			min = distance;
		}

		if (min == max)
		{
			max++;
		}

		if(InitialCalibration == true)
		{
			InitialCalibration = false;
		}
	}

	public float getDistanceValue()
	{
		return BlendValue;
	}

	public float getAngleValue()
	{
		return BlendValueAngle;
	}


}

