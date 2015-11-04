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
			print ("1");
			if (Input.GetButtonDown ("Interact")) {
				print ("2");
				doDmg = true;
				//hit animatie	
				timer = attackRate;
			}
		} else {
			timer -=Time.deltaTime;
		}
	}

	void OnTriggerStay(Collider collision){
		print ("3");
		if (doDmg) {
			print ("4");
			if (collision.transform.tag == "Enemy") {
				print ("5");
				collision.transform.GetComponent <EnemyHealth> ().HealthEnemy (damage);
			}
			doDmg = false;
		}
		print (collision);
	}
}