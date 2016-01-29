using UnityEngine;
using System.Collections;

public class ActivateNextLevel : MonoBehaviour {
	public GameObject nextLevelTarget;
	public GameObject nextLevelText;
	private Vector3 nextPosition;

	//Heb dit script gewijzigd, omdat we maar in-game scene hebben, Mack;
	void OnTriggerStay (Collider collision){
		if(collision.transform.tag == "Player"){
			nextLevelText.SetActive(true);
			if(Input.GetButtonDown("Interact")){
				NextLevel(collision.gameObject);
				nextLevelText.SetActive(false);
			}
		}
	}

	void OnTriggerExit (Collider collision){
		if(collision.transform.tag == "Player"){
			nextLevelText.SetActive(false);
			NextLevel(collision.gameObject);
		}
	}

	public void NextLevel(GameObject player){
		nextPosition = nextLevelTarget.GetComponent<Transform>().position;
		player.GetComponent<Transform>().position = nextPosition;
	}

	//Allieke's gedeelte
//	public GameObject nextScene;
//	public Transform spawnPos;
//	GameObject spawnedText ;
//	public Transform theCanvas;
//	public bool maySpawn;
//	public bool mayGo;
//
//	void OnTriggerStay (Collider collision){
//		if(collision.transform.tag == "NextLevel"){
//			if(maySpawn){
//				spawnedText = (GameObject) Instantiate (nextScene,spawnPos.position,Quaternion.identity);
//				print (spawnedText);
//				spawnedText.transform.SetParent(theCanvas);
//				maySpawn = false;
//			}
//			if(Input.GetButtonDown("Interact")|| mayGo){
//					collision.transform.GetComponent<LoadNextLevel>().GoToNextLevel();
//			}
//		}
//	}
}
