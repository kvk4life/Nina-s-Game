using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public float damage;
	RaycastHit pleh;
	public Color meh;

	void Update (){
		if(Input.GetKeyDown (KeyCode.E)){
			//hit animatie	
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.transform.tag == "Enemy"){
			collision.transform.GetComponent <EnemyHealth>().HealthEnemy(damage);
		}
		print (collision);
	}
}