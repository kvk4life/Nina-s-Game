using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {
	public void OnTriggerEnter(Collider colli){
		if(colli.transform.tag == "Player"){
			colli.GetComponent<BreathHolding>().inSafeZone = true;
		}
	}
	
	public void OnTriggerExit(Collider col2){
		if(col2.transform.tag == "Player"){
			col2.GetComponent<BreathHolding>().inSafeZone = false;
		}
	}
}
