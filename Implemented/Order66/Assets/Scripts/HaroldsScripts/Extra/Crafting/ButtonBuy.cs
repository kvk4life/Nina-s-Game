using UnityEngine;
using System.Collections;

public class ButtonBuy : MonoBehaviour 
{
	public int seedAmount;
	public GameObject weaponEffect;
	public int buyAmount;
	public GameObject[] buttonlist;

	public void BuyCrit()
	{
		if(seedAmount >= buyAmount)
		{
			weaponEffect.GetComponent<Needle>().needleCrit = true;
			seedAmount -= buyAmount;
			buttonlist[0].SetActive(false);
		}
	}

	public void BuyBleed()
	{
		if(seedAmount >= buyAmount)
		{
			weaponEffect.GetComponent<Needle>().needleBleed = true;
			seedAmount -= buyAmount;
			buttonlist[1].SetActive(false);
		}
	}

	public void BuyStun()
	{
		if(seedAmount >= buyAmount)
		{
			weaponEffect.GetComponent<Wooden>().woodStun = true;
			seedAmount -= buyAmount;
			buttonlist[2].SetActive(false);
		}
	}

	public void BuyShield()
	{
		if(seedAmount >= buyAmount)
		{
			weaponEffect.GetComponent<Shield>().shieldPush = true;
			seedAmount -= buyAmount;
			buttonlist[3].SetActive(false);
		}
	}

	public void BuySpring()
	{
		if(seedAmount >= buyAmount)
		{
			weaponEffect.GetComponent<Spring>().springLeap = true;
			seedAmount -= buyAmount;
			buttonlist[4].SetActive(false);
		}
	}
}
