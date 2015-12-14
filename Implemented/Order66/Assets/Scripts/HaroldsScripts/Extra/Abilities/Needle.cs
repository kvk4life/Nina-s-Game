using UnityEngine;
using System.Collections;

public class Needle : WeaponEffect 
{
	public bool needleCrit;
	public bool needleBleed;
	public GameObject enemy;
	public float startBleedAmount;
	public float randomNum;
	public float critChance;
	public int critDamage;
	public int bleedTime;



	void Update ()
	{
		weaponAttack = attackPower;

		if(Input.GetButtonDown("b"))
		{
			BleedAttack();
		}

		if(Input.GetButtonDown("c"))
		{
			CriticalAttack();
		}

	}

	void BleedAttack ()
	{
		Bleed bleedScript = enemy.GetComponent<Bleed> ();
		WeaponSwitch switchScript = GetComponent<WeaponSwitch>();

		if(needleBleed)
		{
			if(switchScript.weaponNumber == 2)
			{
				if(bleedScript.bleedCount < 5)
				{
					bleedScript.timer = bleedTime;
					bleedScript.bleedCount+= 1;
					bleedScript.bleedAmount = startBleedAmount * bleedScript.bleedCount;
				}
			}
		}
	}

	void CriticalAttack()
	{
		EnemyHealth healthScript = enemy.GetComponent<EnemyHealth> ();
		randomNum = (Random.Range(0, 100));

		if(randomNum < critChance)
		{
			critDamage = weaponAttack *= 2;
			healthScript.health-= critDamage;
		}
	}
}
