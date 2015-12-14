using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour 
{
	public int weaponNumber;
	public GameObject[] weaponList;
	

	void Update ()
	{
		if(Input.GetButtonDown("1"))
		{
			SwitchWeaponWood();
		}

		if(Input.GetButtonDown("2"))
		{
			SwitchWeaponNeedle();
		}
	}

	void SwitchWeaponWood()
	{
		if(weaponNumber == 2)
		{
			weaponNumber = 1;
			//hud image = number 2
			//animation switch
			weaponList[1].SetActive(true);
			weaponList[0].SetActive(false);
		}
	}

	void SwitchWeaponNeedle()
	{
		if(weaponNumber == 1)
		{
			weaponNumber = 2;
			//hud image = number 1
			//animation switch
			weaponList[0].SetActive(true);
			weaponList[1].SetActive(false);
		}
	}
}
