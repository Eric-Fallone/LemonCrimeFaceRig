using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkInfoProcesser : MonoBehaviour
{
	private static LandMarkInfoProcesser _S;
	public static LandMarkInfoProcesser S{ get { return _S; } } 

	public BlendtreeLandMarkHandler[] LandMarkHandlers;

	public Vector2[] LandMarks = new Vector2[68];

	public Vector2 FaceLocation;

	private void Awake()
	{
		if (_S != null && _S != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_S = this;
		}
	}

	public void ProcessInfo(string LandMarksRecieved)
	{
		//Clean up string
		LandMarksRecieved = LandMarksRecieved.Replace("\"","");
		LandMarksRecieved = LandMarksRecieved.Replace("]", "");
		LandMarksRecieved = LandMarksRecieved.Replace("[", "");
		LandMarksRecieved = LandMarksRecieved.Replace(" ", "");


		string[] splitLandMarks = LandMarksRecieved.Split(',');
		
		//No Face detected
		if (splitLandMarks.Length != 207 )
		{
			return;
		}

		FaceLocation.x = int.Parse(splitLandMarks[1]);
		FaceLocation.y = int.Parse(splitLandMarks[2]);

		int index = 0;
		for (int i = 3 ; i < splitLandMarks.Length ; i = i+3)
		{
			//Debug.Log("Index: " + splitLandMarks[i] + " X: " + splitLandMarks[i+1] + " Y: " + splitLandMarks[i+2]);
			LandMarks[index].x = int.Parse(splitLandMarks[i + 1]);
			LandMarks[index].y = int.Parse(splitLandMarks[i + 2]);
			index++;
		}

		foreach (BlendtreeLandMarkHandler handler in LandMarkHandlers)
		{
			int[] indexes = handler.getIndexes();

			handler.SetLandMarks(LandMarks[indexes[0]].x, LandMarks[indexes[0]].y,
								LandMarks[indexes[1]].x, LandMarks[indexes[1]].y);
		}
	}
}
