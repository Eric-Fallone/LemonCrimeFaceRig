using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Blend Tree Land Mark Handler", menuName = "ScriptableObjects/BlendtreeLandMarkHandler")]
public class BlendtreeLandMarkHandler : ScriptableObject
{
	public bool DebugPrint = false;
	public int[] IndexesOfLandMarks;
	//private Vector2[] LandMarks;
	public string BlendtreeName;
	[SerializeField]
	private float BlendValue;

	public float min;
	public float max;

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
		float distance = Mathf.Clamp( Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)), min, max );
		float value = (distance - min) / (max - min);
		if (DebugPrint)
		{
			Debug.Log("Distance: " + distance + " Value: " + value);
		}
		BlendValue = Mathf.Clamp(value, 0, 1);
	}
}

