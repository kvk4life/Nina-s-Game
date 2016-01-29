using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float health;
	public float expToPlayer;
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public float HealthEnemy (float damage){
		health -= damage;
		if(health < 1){
			player.GetComponent<PlayerLevel>().GetExp(expToPlayer);
			Destroy (gameObject);
		}
		return health;
	}	

}
