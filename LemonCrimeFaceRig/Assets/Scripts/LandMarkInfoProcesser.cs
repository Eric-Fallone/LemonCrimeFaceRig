using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkInfoProcesser : MonoBehaviour
{
	private static LandMarkInfoProcesser _S;
	public static LandMarkInfoProcesser S{ get { return _S; } } 


	public BlendtreeLandMarkHandler[] LandMarkHandlers;

	public Vector2[] LandMarks = new Vector2[68];

	public Vector2 ScreenInfoWebCam;
	public float webCamToScreenRation; 

	public Vector2 FaceLocation;



	[SerializeField]
	private bool isCalibrating = false;

	[SerializeField]
	private bool isDebug = false;

	public ObjectMover LemonCrime;

	public GameObject[] LandMarkDebuggers;

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
		if (splitLandMarks.Length != 209 )
		{
			return;
		}

		ScreenInfoWebCam.x = float.Parse(splitLandMarks[0]);
		ScreenInfoWebCam.y = float.Parse(splitLandMarks[1]);

		FaceLocation.x = float.Parse(splitLandMarks[3]);
		FaceLocation.y = float.Parse(splitLandMarks[4]);

		Vector2 meow = CalculateScreenRatio();

		//Move Player Avatar to screen space
		MoveMainObjectToScreenPosition();

		int index = 0;
		for (int i = 5 ; i < splitLandMarks.Length ; i = i+3)
		{
			//Debug.Log("Index: " + splitLandMarks[i] + " X: " + splitLandMarks[i+1] + " Y: " + splitLandMarks[i+2]);
			LandMarks[index].x = float.Parse(splitLandMarks[i + 1]);
			LandMarks[index].y = float.Parse(splitLandMarks[i + 2]);
			index++;
		}

		if (isCalibrating == true)
		{
			foreach (BlendtreeLandMarkHandler handler in LandMarkHandlers)
			{
				int[] indexes = handler.getIndexes();

				handler.Calibrate(LandMarks[indexes[0]].x, LandMarks[indexes[0]].y,
								LandMarks[indexes[1]].x, LandMarks[indexes[1]].y);
			}
		}

		foreach (BlendtreeLandMarkHandler handler in LandMarkHandlers)
		{
			int[] indexes = handler.getIndexes();

			handler.SetLandMarks(LandMarks[indexes[0]].x, LandMarks[indexes[0]].y,
								LandMarks[indexes[1]].x, LandMarks[indexes[1]].y);
		}
	}

	public void StartCalibration()
	{
		foreach (BlendtreeLandMarkHandler handler in LandMarkHandlers)
		{
			handler.StartCalibrating();
		}
		isCalibrating = true;
	}

	public void EndCalibration()
	{
		isCalibrating = false;
	}

	private Vector2 CalculateScreenRatio()
	{
		float x = ScreenInfoWebCam.x / Screen.width;
		float y = ScreenInfoWebCam.y / Screen.height;

		Vector2 output = new Vector2(x,y);
		return output;
	}
	
	private void MoveMainObjectToScreenPosition()
	{
		float x = ( (1 - (FaceLocation.x / ScreenInfoWebCam.x) ) * Screen.width );
		float y = ( (1 - (FaceLocation.y / ScreenInfoWebCam.y) ) * Screen.height);
		
		LemonCrime.MoveObjectTowardsLocation(x,y);
	}

	private Vector2 GetScreenLocationOfLandMark(int webCamX, int webCamY)
	{
		Vector2 output = new Vector2(0,0);
		return output;
	}

}
