using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float health;

	public float HealthEnemy (float damage){
		health -= damage;
		if(health < 1){
			Destroy (gameObject);
		}
		return health;
	}	

}
