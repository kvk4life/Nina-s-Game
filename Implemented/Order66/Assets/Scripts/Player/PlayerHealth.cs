using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health;
	public float maxHealth;
	public GameObject gameMNGR;
	public bool immortal;
	public int healthShield;
	
	public void Start(){
		if (health == 0) {
			maxHealth = gameMNGR.GetComponent<Heartscript> ().maxLength * 2;
			health = maxHealth;
		}
	}

	public void MaxHealthConnect(){
		maxHealth = gameMNGR.GetComponent<Heartscript> ().maxLength * 2;
		health = maxHealth;
	}

	public float Damage (float damage){
		if (!immortal) {
			if(healthShield == 0){
				if (health > 0) {
					health -= damage;
					gameMNGR.GetComponent<Heartscript> ().LoseHeart (damage);
				}
				if (health <= 0) {
					gameMNGR.GetComponent<GameOver> ().gameOver = true;
				}
			}
			else{
				healthShield = 0;
				GetComponent<HealthShield>().TimerReset();
			}
		}
		else {
			health = maxHealth;
		}
		return health;
	}

	public void Respawned (){
		gameMNGR.GetComponent<Heartscript>().NewBar();
		gameMNGR.GetComponent<Heartscript>().HudCheck();
		health = maxHealth;
	}
	
	public float Heal (float heal){
		if(health + heal > maxHealth){
			float leftoverHealth = maxHealth - health;
			health = maxHealth;
			gameMNGR.GetComponent<Heartscript>().GainHeart(leftoverHealth);
		}
		else if(health < maxHealth){
			health += heal;
			gameMNGR.GetComponent<Heartscript>().GainHeart(heal);
		}
		return health;
	}
}