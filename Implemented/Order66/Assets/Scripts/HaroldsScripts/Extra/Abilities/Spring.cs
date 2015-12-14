using UnityEngine;
using System.Collections;

public class Spring : WeaponEffect 
{
	public bool springLeap;
	public GameObject player;
	public GameObject enemy;
	public Rigidbody rb;
	public int leapHeight;
	public float leapDistancez;
	public float leapDistancex;
	public float leapCooldown;
	public bool heightCheck;
	public Vector3 heightCheker;
	public float endLeapHeight;
	public int leapDrag;
	public int leapDamage;


	void Start ()
	{
		rb = player.GetComponent<Rigidbody>();
	}

	void Update () 
	{
		if(timer >= 0)
		{
			timer-= 1 * Time.deltaTime;
		}

		if(heightCheck)
		{
			if(player.transform.position.y >= heightCheker.y)
			{
				rb.velocity = new Vector3 (0, leapDrag, 0);
				heightCheck = false;
			}
		}
	}

	public void LeapAttack ()
	{
		if(springLeap)
		{
			if(timer <= 0)
			{
				EnemyHealth healthScript = enemy.GetComponent<EnemyHealth> ();
				leapDistancez = enemy.transform.position.z - player.transform.position.z;
				leapDistancex = enemy.transform.position.x - player.transform.position.x;
				rb.velocity = new Vector3 (leapDistancex, leapHeight, leapDistancez);
				timer = leapCooldown;
				heightCheck = true;
				heightCheker = player.transform.position;
				heightCheker.y+= endLeapHeight;
				healthScript.health-= leapDamage;
			}
		}
	}
}
