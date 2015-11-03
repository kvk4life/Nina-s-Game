using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health;
	private float beginHealth;
	public GameObject gameMNGR;

	void Start (){
		beginHealth = health;
	}

	public float Damage (float damage){
		health -= damage;
		gameMNGR.GetComponent<Heartscript> ().LoseHeart ();
		if (health <= 0) {
			gameMNGR.GetComponent<GameOver>().GameOverSwitch();
			gameMNGR.GetComponent<Respawn> ().Respawning ();
		}
		return health;
	}

	public void Update(){
		if(health <= 0){
			//Game Over Scherm.
			gameMNGR.GetComponent<Respawn> ().Respawning();
		}
	}
	public void Respawn (){
		health = beginHealth;
	}

	public float Heal (float heal){
		if(health <= 5){
			health += heal;
			gameMNGR.GetComponent<Heartscript>().GainHeart();
		}
		return health;
	}
}
