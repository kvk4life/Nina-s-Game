using UnityEngine;
using System.Collections;

public class Bleed : MonoBehaviour 
{
	public float timer;
	public int bleedCount;
	public bool bleeding;
	public float bleedAmount;



	void Update () 
	{
		if(timer > 0)
		{
			bleeding = true;
			timer-= 1 * Time.deltaTime;
		}
		else
		{
			timer = 0;
			bleedCount = 0;
			bleeding = false;
		}
		
		if(bleeding)
		{
			EnemyHealth healthScript = GetComponent<EnemyHealth> ();
			healthScript.health-= bleedAmount * Time.deltaTime;
		}
	}
}
