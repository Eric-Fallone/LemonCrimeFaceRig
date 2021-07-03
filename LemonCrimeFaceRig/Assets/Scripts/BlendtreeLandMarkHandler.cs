using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[CreateAssetMenu(fileName = "Blend Tree Land Mark Handler", menuName = "ScriptableObjects/BlendtreeLandMarkHandler")]
public class BlendtreeLandMarkHandler : ScriptableObject
{
	public bool DebugPrint = false;
	public int[] IndexesOfLandMarks = new int[2];

	[SerializeField, Range(0,1) ]
	private float BlendValue;
	[Range(0, 1)]
	public float DeadBandMin = 0;
	[Range(0, 1)]
	public float DeadBandMax = 1;
	[SerializeField]
	private float BlendValueAngle;

	public float min = 0;
	public float max = 1;
	[SerializeField]
	private bool InitialCalibration = false;

	[SerializeField]
	private float output;

	public bool isReversed = false;

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
		float value = (distance - min ) / (max - min);
		if (DebugPrint)
		{
			Debug.Log("Distance: " + distance + " Value: " + value);
		}
		BlendValue = Mathf.Clamp(value, 0, 1);


		float sign = (second.y < first.y) ? -1.0f : 1.0f;
		BlendValueAngle = Vector2.Angle( LandMarkInfoProcesser.S.FaceAngle , (second - first)) *sign ;

		if(isReversed == true)
		{
			BlendValue = 1 - BlendValue; 
		}

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
		if (BlendValue < DeadBandMin )
		{
			output = 0;
			return 0;
		}
		if (BlendValue > DeadBandMax)
		{
			output = 1;
			return 1;
		}
		if ( (DeadBandMax ==0 && DeadBandMin == 0) || DeadBandMax-DeadBandMin ==0 )
		{
			output = 0;
			return 0;
		}
		output = (BlendValue - DeadBandMin) / (DeadBandMax - DeadBandMin);
		return (BlendValue - DeadBandMin)/(DeadBandMax - DeadBandMin);
	}

	public float getAngleValue()
	{
		return BlendValueAngle;
	}


}

