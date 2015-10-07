using UnityEngine;
using System.Collections;

public class WaterDeath : MonoBehaviour {
	public GameObject player;

	void OnCollisionEnter(Collision col){
		//Wanneer de DeathBlock, een ontzichtbaar G.O. boven het hoofd van Nina
		//In het water terecht komt is Nina instakillt
		if(col.transform.tag == "DeathBlock"){
			player.GetComponent<PlayerHealth> ().health = 0;
		}
	}
}
