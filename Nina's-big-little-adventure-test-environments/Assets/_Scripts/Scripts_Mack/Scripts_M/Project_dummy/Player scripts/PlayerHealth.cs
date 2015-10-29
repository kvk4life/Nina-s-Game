using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health;
	GameObject gameMng;
	bool dead;
	public bool immortal;
	
	public void Start(){
		gameMng = GameObject.Find ("GameMng");
	}
	
	public float Damage (float damage){
		if (!immortal) {
			if (health > 0) {
				health -= damage;
			}
			if (health < 1) {
				Death ();
			}
		} 
		else {
			health = 3;
		}
		return health;
	}
	
	public void Death(){
		gameMng.GetComponent<GameOver>().gameOver = true;
		gameMng.GetComponent<Respawn> ().Respawning();
	}
	
	public float Heal (float heal){
		if(health < 3){
			health += heal;
		}
		return health;
	}
}