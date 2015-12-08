using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health;
	public float maxHealth;
	public GameObject gameMNGR;
	public bool immortal;
	
	public void Start(){
		if(health == 0){
			health = maxHealth;
		}
	}
	
	public float Damage (float damage){
		if (!immortal) {
			if (health > 0) {
				health -= damage;
				gameMNGR.GetComponent<Heartscript> ().LoseHeart (damage);
			}
			if (health <= 0) {
				gameMNGR.GetComponent<GameOver> ().gameOver = true;
			}
		}
		else {
			health = maxHealth;
		}
		return health;
	}
	
	public void Respawned (){
		Heal (maxHealth);
	}
	
	public float Heal (float heal){
		if(health < maxHealth){
			health += heal;
			gameMNGR.GetComponent<Heartscript>().GainHeart(heal);
		}
		return health;
	}
}