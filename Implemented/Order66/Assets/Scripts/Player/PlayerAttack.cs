using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public float damage;
	public bool doDmg;
	public float timer;
	public float attackRate;

	void Start (){
		timer = attackRate;
	}

	void Update (){
		if (timer < 1) {
			if (Input.GetButtonDown ("Interact")) {
				doDmg = true;
				//hit animatie	
				timer = attackRate;
			}
		} else {
			timer -=Time.deltaTime;
		}
	}

	void OnTriggerStay(Collider collision){
		if (doDmg) {
			if (collision.transform.tag == "Enemy") {
				collision.transform.GetComponent <EnemyHealth> ().HealthEnemy (damage);
			}
			doDmg = false;
		}
	}
}