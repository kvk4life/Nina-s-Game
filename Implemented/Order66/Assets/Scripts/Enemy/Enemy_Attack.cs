using UnityEngine;
using System.Collections;

public class Enemy_Attack : Enemy_Stats {
	float nextAttack;
	public GameObject player;

	void OnTriggerStay(Collider inCol){
		if(inCol.tag == "Player"){
			AttackIt ();
		}
	}

	void AttackIt(){
		if (Time.time > attackRate + nextAttack) {
			DamageCheck();
			nextAttack = Time.time;
		}
	}

	void DamageCheck(){
		if (player.GetComponent<Defense> ().blocken) {
			player.GetComponent<Stamina> ().StaminaReduction (staminaDamage);
			if(player.GetComponent<Defense>().shieldMaxed){
				player.GetComponent<Defense>().BlockCounter();
			}
		}
		else {
			player.GetComponent<PlayerHealth> ().Damage (power);
		}
	}
}
