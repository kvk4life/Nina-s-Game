using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public float damage;
	public float timer;
	private float attackRate;
	public float comboCounter = 1;
	public float staminaCost;
	private GameObject theTarget;

	void Start (){
		attackRate = timer;
	}

	void Update (){
		if (timer < 1) {
			if (Input.GetButtonDown("Fire1")) {
				timer = attackRate;
				ComboTimer();
				GetComponent<Stamina>().StaminaReduction(staminaCost);
			}
		}
		else {
			timer -=Time.deltaTime;
		}
	}

	void ComboTimer(){
		GetComponent<Play_Animation> ().Attack ();
		Damager ();
	}

	public void Targeter(GameObject myTarget){
		theTarget = myTarget;
	}

	void Damager(){
		theTarget.transform.GetComponent <EnemyHealth> ().HealthEnemy (damage);
	}
}