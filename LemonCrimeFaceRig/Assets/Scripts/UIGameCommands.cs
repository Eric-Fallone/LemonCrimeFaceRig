using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameCommands : MonoBehaviour
{

	public ToggleActive ButtonGroups;

	public void ExitApplication()
	{
		Application.Quit();
	}
	public void Update()
	{
		if ( (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) && Input.GetKeyDown(KeyCode.L))
		{
			ButtonGroups.toggleVisability();
		}
	}
}
