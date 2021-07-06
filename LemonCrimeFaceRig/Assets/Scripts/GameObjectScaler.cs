using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class GameObjectScaler : MonoBehaviour
{
	public TMP_InputField scaleInput;
	//public TMPro 

	
	public void SetScale()
	{
		string decimalString = scaleInput.text;
		Debug.Log(decimalString);
		//float value = float.Parse(decimalString, NumberStyles.Any, CultureInfo.CurrentCulture);
		float value = float.Parse(decimalString, NumberStyles.Any, new CultureInfo("en-US"));

		Debug.Log("value");

		this.transform.localScale =  new Vector3(value, value, value);
	}
}
