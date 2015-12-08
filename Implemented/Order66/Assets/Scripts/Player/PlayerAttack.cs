using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private GameObject playerObject;
	public float damage;
	public bool doDmg;
	public float timer;
	public float attackRate;
	public float staminaCost;

	void Start (){
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		timer = attackRate;
	}

	void Update (){
		if (timer < 1) {
			if (Input.GetButtonDown("Fire1")) {
				doDmg = true;
				//hit animatie	
				timer = attackRate;
				playerObject.GetComponent<Stamina>().StaminaReduction(staminaCost);
			}
		} else {
			timer -=Time.deltaTime;
		}
	}

	void OnCollision(Collider collision){
		if (doDmg) {
			if (collision.transform.tag == "Enemy") {
				collision.transform.GetComponent <EnemyHealth> ().HealthEnemy (damage);
			}
			doDmg = false;
		}
	}
}