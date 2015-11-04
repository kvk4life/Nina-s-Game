using UnityEngine;
using System.Collections;

public class WaterDeath : MonoBehaviour {
	
	void OnTriggerEnter(Collider col){
		print (col);
		//Wanneer de DeathBlock, een ontzichtbaar G.O. boven het hoofd van Nina
		//In het water terecht komt is Nina instakillt
		if(col.transform.tag == "Water"){
			GetComponent<PlayerHealth> ().health = 0;
		}
	}
}
