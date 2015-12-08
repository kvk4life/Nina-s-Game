using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public int CheckPointNumber;
	public bool maySpawn;
	public GameObject restText;

	public void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player"){
			if (maySpawn) {
				restText.SetActive(true);
				maySpawn = false;
			}
		}
	}

	public void OnTriggerStay(Collider col){
		if(col.transform.tag == "Player"){
			if(Input.GetButtonDown ("Interact")){
				GameObject.Find ("GameManager").GetComponent<Respawn>().SetCheckPoint(CheckPointNumber);
			}
		}
	}

	public void OnTriggerExit (){
		if (!maySpawn) {
			maySpawn = true;
			restText.SetActive(false);
		}
	}
}
