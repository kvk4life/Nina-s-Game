using UnityEngine;
using System.Collections;

public class TriggerAnimatie : MonoBehaviour {
	public GameObject nextCam;
	bool swap = true;

	void OnTriggerStay (Collider collision){
		if(collision.transform.tag == "Anim"){
			if(swap){
				Camera.main.gameObject.SetActive(false);
				nextCam.gameObject.SetActive(true);
				swap = false;
			}
		}
	}
}
