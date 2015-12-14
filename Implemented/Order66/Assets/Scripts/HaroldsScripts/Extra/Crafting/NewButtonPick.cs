using UnityEngine;
using System.Collections;

public class NewButtonPick : MonoBehaviour 
{
	public GameObject[] imageList;
	public GameObject critBuy;
	public GameObject bleedBuy;
	public GameObject shieldBuy;
	public GameObject springBuy;
	public GameObject stunBuy;
	public AIStates aiStates;
	public bool onOff;

	public enum AIStates
	{
		Nothing,
		Crit,
		Stun,
		Bleed,
		Spring,
		Shield
	}

	void Start()
	{
		onOff = true;
	}

	public void ButtonBack()
	{
		SwitchOnOff();
		aiStates = AIStates.Nothing;

	}

	public void ButtonPickCrit()
	{
		SwitchOnOff();
		aiStates = AIStates.Crit;
	}

	public void ButtonPickStun()
	{
		SwitchOnOff();
		aiStates = AIStates.Stun;
	}

	public void ButtonPickBleed()
	{
		SwitchOnOff();
		aiStates = AIStates.Bleed;
	}

	public void ButtonPickSpring()
	{
		SwitchOnOff();
		aiStates = AIStates.Spring;
	}

	public void ButtonPickShield()
	{
		SwitchOnOff();
		aiStates = AIStates.Shield;
	}

	void SwitchOnOff()
	{
		if(onOff)
		{
			for (int i = 0; i < imageList.Length; i++)
			{
				imageList[i].SetActive(false);
			}
			onOff = false;
		}
		else
		{
			for (int i = 0; i < imageList.Length; i++)
			{
				imageList[i].SetActive(true);
			}
			onOff = true;
		}
	}
	void Update()
	{
		if(aiStates == AIStates.Nothing)
		{
			bleedBuy.SetActive(false);
			shieldBuy.SetActive(false);
			springBuy.SetActive(false);
			critBuy.SetActive(false);
			stunBuy.SetActive(false);
		}

		if(aiStates == AIStates.Crit)
		{
			bleedBuy.SetActive(false);
			shieldBuy.SetActive(false);
			springBuy.SetActive(false);
			critBuy.SetActive(true);
			stunBuy.SetActive(false);
		}

		if(aiStates == AIStates.Stun)
		{
			bleedBuy.SetActive(false);
			shieldBuy.SetActive(false);
			springBuy.SetActive(false);
			critBuy.SetActive(false);
			stunBuy.SetActive(true);
		}

		if(aiStates == AIStates.Bleed)
		{
			bleedBuy.SetActive(true);
			shieldBuy.SetActive(false);
			springBuy.SetActive(false);
			critBuy.SetActive(false);
			stunBuy.SetActive(false);
		}

		if(aiStates == AIStates.Spring)
		{
			bleedBuy.SetActive(false);
			shieldBuy.SetActive(false);
			springBuy.SetActive(true);
			critBuy.SetActive(false);
			stunBuy.SetActive(false);
		}

		if(aiStates == AIStates.Shield)
		{
			bleedBuy.SetActive(false);
			shieldBuy.SetActive(true);
			springBuy.SetActive(false);
			critBuy.SetActive(false);
			stunBuy.SetActive(false);
		}
	}
}
