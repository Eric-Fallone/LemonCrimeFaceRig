using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saver : MonoBehaviour
{
	private static Saver _S;
	public static Saver S { get { return _S; } }

	public GameObject Face;
	public GameObject Slice;

	public TMP_Text FaceScaleUI;
	public TMP_InputField FaceScaleInput;
	public TMP_Text MouseScaleUI;
	public TMP_InputField MouseScaleInput;


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

	public void Start()
	{
		LoadGameObjects();
	}

	public void SaveLocation(GameObject objIn)
	{
		PlayerPrefs.SetFloat(objIn.name + "LocX",objIn.transform.position.x);
		PlayerPrefs.SetFloat(objIn.name + "LocY", objIn.transform.position.y);
		PlayerPrefs.SetFloat(objIn.name + "LocZ", objIn.transform.position.z);
	}

	public void SaveScale(GameObject ObjIn)
	{
		PlayerPrefs.SetFloat(ObjIn.name+"Scale", ObjIn.transform.localScale.x);
	}

	public void SaveIsActive(GameObject ObjIn)
	{
		int temp = 1;
		if (ObjIn.activeSelf == false)
		{
			temp = 0;
		}
		PlayerPrefs.SetInt(ObjIn.name + "IsShowing", temp);
	}

	public void LoadGameObjects()
	{

		//face locations
		Vector3 tempLoc = new Vector3(
			PlayerPrefs.GetFloat(Face.name + "LocX",0),
			PlayerPrefs.GetFloat(Face.name + "LocY",0),
			PlayerPrefs.GetFloat(Face.name + "LocS",0) );

		Face.transform.position = tempLoc;

		//face scale
		float faceScale = PlayerPrefs.GetFloat(Face.name+"Scale",1);
		
		Face.transform.localScale = new Vector3(faceScale,faceScale,faceScale);

		float mouseScale = PlayerPrefs.GetFloat(Slice.name + "Scale",.2f);
		Slice.transform.localScale = new Vector3(mouseScale, mouseScale, mouseScale);

		// is mouse showing
		int isMouseShowingHelper = PlayerPrefs.GetInt(Slice.name + "IsShowing",0);
		if (isMouseShowingHelper == 0)
		{
			Slice.SetActive(false);
		}
		else
		{
			Slice.SetActive(true);
		}


		//ui buttons
		FaceScaleInput.text = "" + faceScale;
		MouseScaleInput.text = "" + mouseScale;


	}
}
