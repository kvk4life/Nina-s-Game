using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health;
	private float beginHealth;

	void Start (){
		beginHealth = health;
	}

	public float Damage (float damage){
		health -= damage;
		if (health <= 0) {
			GameObject.Find ("GameManager").GetComponent<Respawn> ().Respawning ();
		}
		return health;
	}

	public void Update(){
		//Testing Respawning
		if(health <= 0){
			//Game Over Scherm.
			GameObject.Find ("GameManager").GetComponent<Respawn> ().Respawning();
		}
	}
	public void Respawn (){
		health = beginHealth;
	}

	public float Heal (float heal){
		if(health <= 2){
			health += heal;
		}
		return health;
	}
}
