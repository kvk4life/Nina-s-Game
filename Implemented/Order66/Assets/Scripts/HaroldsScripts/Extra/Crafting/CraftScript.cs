using UnityEngine;
using System.Collections;

public class CraftScript : MonoBehaviour 
{
	public GameObject craftDisplay;
	public bool craftWindown;


	void Update () 
	{
		if(Input.GetButtonDown("i"))
		{
			SetOff();
		}
	}

	void SetOff()
	{
		if(craftWindown == false)
		{
			craftDisplay.SetActive(true);
		}
		else
		{
			craftDisplay.SetActive(false);
		}
	}
}
