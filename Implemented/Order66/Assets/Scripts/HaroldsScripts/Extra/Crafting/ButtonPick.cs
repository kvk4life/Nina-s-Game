using UnityEngine;
using System.Collections;

public class ButtonPick : MonoBehaviour 
{
	//public GameObject[] imageList;
	public GameObject critBuy;
	public GameObject bleedBuy;
	public GameObject shieldBuy;
	public GameObject springBuy;
	public bool onOff;

	void start()
	{
		//onOff = true;
	}

	public void ButtonPickCrit()
	{	
		//SwitchOnOff();
		bleedBuy.SetActive(false);
		shieldBuy.SetActive(false);
		springBuy.SetActive(false);
		critBuy.SetActive(true);
	}

	public void ButtonPickBleed()
	{
		//SwitchOnOff();
		bleedBuy.SetActive(true);
		shieldBuy.SetActive(false);
		springBuy.SetActive(false);
		critBuy.SetActive(false);
	}

	public void ButtonPickShield()
	{
		//SwitchOnOff();
		bleedBuy.SetActive(false);
		shieldBuy.SetActive(true);
		springBuy.SetActive(false);
		critBuy.SetActive(false);
	}

	public void ButtonPickSpring()
	{
		//SwitchOnOff();
		bleedBuy.SetActive(false);
		shieldBuy.SetActive(false);
		springBuy.SetActive(true);
		critBuy.SetActive(false);
	}

//	void SwitchOnOff()
//	{
//		if(onOff)
//		{
//			for (int i = 0; i < imageList.Length; i++)
//			{
//				imageList[i].SetActive(false);
//			}
//			onOff = false;
//		}
//		else
//		{
//			for (int i = 0; i < imageList.Length; i++)
//			{
//				imageList[i].SetActive(true);
//			}
//			onOff = true;
//		}
//	}
}
