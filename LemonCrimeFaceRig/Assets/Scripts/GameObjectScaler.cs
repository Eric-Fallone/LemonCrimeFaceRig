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
		float value = float.Parse(decimalString, NumberStyles.Any, new CultureInfo("en-US"));

		this.transform.localScale =  new Vector3(value, value, value);
	}
}
