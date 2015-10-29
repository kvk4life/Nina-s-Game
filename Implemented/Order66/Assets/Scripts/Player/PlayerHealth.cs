using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health;
	
	public float Damage (float damage){
		health -= damage;
		if(health <= 0){
			GameObject.Find ("GameManager").GetComponent<Respawn> ().Respawning();
			Destroy(gameObject);
		}
		return health;
	}

	public void Update(){
		//Testing Respawning
		if(health <= 0){
			//Game Over Scherm.
			GameObject.Find ("GameManager").GetComponent<Respawn> ().Respawning();
			Destroy(gameObject);
		}
	}

	public float Heal (float heal){
		if(health <= 2){
			health += heal;
		}
		return health;
	}
}
