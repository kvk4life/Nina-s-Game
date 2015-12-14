using UnityEngine;
using System.Collections;

public class Shield : WeaponEffect 
{
	public bool shieldPush;
	public GameObject enemy;
	public GameObject player;
	public float shieldCoolDown;
	public Rigidbody erb;
	public Vector3 enemyPosition;
	public Vector3 playerPosition;
	public Vector3 pushPower;
	public int minPush;
	
	void Update () 
	{
		if(timer >= 0)
		{
			timer-= 1 * Time.deltaTime;
		}
	}

	public void ShieldAttack ()
	{
		if(shieldPush)
		{
			if(timer <= 0)
			{
				erb = enemy.GetComponent<Rigidbody>();
				enemyPosition = enemy.transform.position;
				playerPosition = player.transform.position;
				pushPower = enemyPosition-= playerPosition;
				PushCheck();
				erb.velocity = new Vector3 (pushPower.x, pushPower.y, pushPower.z);
				timer = shieldCoolDown;
			}
		}
	}

	void PushCheck ()
	{
		if(pushPower.x > 0)
		{
			pushPower.x = minPush;
		}
		else
		{
			pushPower.x = -minPush;
		}

		if(pushPower.z > 0)
		{
			pushPower.z = minPush;
		}
		else
		{
			pushPower.z = -minPush;
		}
	}

}

