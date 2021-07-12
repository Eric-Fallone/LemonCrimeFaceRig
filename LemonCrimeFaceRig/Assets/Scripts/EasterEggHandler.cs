using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggHandler : MonoBehaviour
{
	string[] easterEggsInputs = new string[]
	{"muck"};

	public List<int> activeEasterEggs = new List<int>();
	int currentIndex = 0;

	// Start is called before the first frame update
	public LookAtTransform LeftEye;
	public LookAtTransform RightEye;


	// Update is called once per frame
	void Update()
    {
		if (Input.anyKeyDown)
		{
			int checker = CheckInput();

			if (checker == 0)
			{
				LeftEye.MuckMuck();
				RightEye.MuckMuck();
			}
		}
	}

	private int CheckInput()
	{
		if (activeEasterEggs.Count > 0)
		{
			bool found = false;
			for(int i = activeEasterEggs.Count - 1 ; i  >= 0 ; i --)
			{
				if (currentIndex < easterEggsInputs[i].Length && easterEggsInputs[i].Substring(currentIndex, 1) == Input.inputString)
				{
					found = true;
					if (easterEggsInputs[i].Length - 1 == currentIndex)
					{
						activeEasterEggs.Clear();
						return i;
					}
				}
				else
				{
					activeEasterEggs.Remove(i);
				}
			}
			if (found == true)
			{
				currentIndex++;
			}
		}
		else
		{
			for (int i = 0; i < easterEggsInputs.Length; i++)
			{
				if (easterEggsInputs[i].Substring(0,1) == Input.inputString)
				{
					activeEasterEggs.Add(i);
					currentIndex = 1;
				}
			}
		}
		return -1;
	}
}
