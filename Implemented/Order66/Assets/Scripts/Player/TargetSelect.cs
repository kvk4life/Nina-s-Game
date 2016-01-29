using UnityEngine;
using System.Collections;

public class TargetSelect : MonoBehaviour {
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter(Collider col){
		if (col.transform.tag == "Enemy") {
			player.GetComponent<PlayerAttack> ().Targeter (col.gameObject);
		}
		else {
			return;
		}
	}

}
