using UnityEngine;
using System.Collections;

public class Wooden : WeaponEffect 
{
	public bool woodStun;
	public GameObject enemy;

	void Update () 
	{
		weaponAttack = attackPower;


		if(timer > 0)
		{
			timer-= 1 * Time.deltaTime;
		}

	}

	public void Stun()
	{
		EnemyAI aiScript = enemy.GetComponent<EnemyAI> ();
		WeaponSwitch switchScript = GetComponent<WeaponSwitch>();

		if(timer <= 0)
		{
			if(woodStun)
			{
				if(switchScript.weaponNumber == 1)
				{
					timer = 5;
					aiScript.timer = 2;
					aiScript.aiStates = EnemyAI.AIStates.Stunned;
				}
			}
		}
	}	
}
