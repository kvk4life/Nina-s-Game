using UnityEngine;
using System.Collections;

public class SkillUse : MonoBehaviour 
{
	private RaycastHit hit;
	public int distance;
	public GameObject weaponEffects;

	void Update () 
	{
		if (Physics.Raycast (transform.position, transform.forward, out hit, distance))
		{
			if(hit.transform.gameObject.tag == "enemy")
			{
				if(Input.GetButtonDown("p"))
				{
					Shield shieldScript = weaponEffects.GetComponent<Shield> ();
					shieldScript.enemy = hit.transform.gameObject;
					shieldScript.ShieldAttack();
			
				}

				if(Input.GetButtonDown("t"))
				{
					Wooden woodScript = weaponEffects.GetComponent<Wooden> ();
					woodScript.enemy = hit.transform.gameObject;
					woodScript.Stun();
				}

				if(Input.GetButtonDown("x"))
				{
					Spring springScript = weaponEffects.GetComponent<Spring> ();
					springScript.enemy = hit.transform.gameObject;
					springScript.LeapAttack();
				}
			}
		}
	}
}
