using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour 
{
	public int weaponNumber;
	public GameObject[] weaponList;
	public GameObject[] hudImageList;
	public Sprite[] hudList;
	
	void Start()
	{
		weaponNumber = 1;
	}
	
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
			hudImageList[0].GetComponent<SpriteRenderer> ().sprite = hudList[0];
			hudImageList[1].GetComponent<SpriteRenderer> ().sprite = hudList[1];
			//hudImageList[1] = hudList[0];
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
			hudImageList[0].GetComponent<SpriteRenderer> ().sprite = hudList[1];
			hudImageList[1].GetComponent<SpriteRenderer> ().sprite = hudList[0];
			weaponList[0].SetActive(true);
			weaponList[1].SetActive(false);
		}
	}
}
