using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public int CheckPointNumber;
	public bool maySpawn;
	public GameObject shownText;
	public GameObject restText;
	public Transform theCanvas;
	public Transform spawnPos;


	public void OnTriggerStay(Collider col){
		if(col.transform.tag == "Player"){
			if (maySpawn) {
				shownText = (GameObject)Instantiate(restText, spawnPos.position, Quaternion.identity);
				shownText.transform.SetParent(theCanvas);
				maySpawn = false;
			}
			if(Input.GetButtonDown ("Interact")){
				GameObject.Find ("GameManager").GetComponent<Respawn>().SetCheckPoint(CheckPointNumber);
			}
		}
	}
	public void OnTriggerExit (){
		if (!maySpawn) {
			maySpawn = true;
		}
	}
}
