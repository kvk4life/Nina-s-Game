using UnityEngine;
using System.Collections;

public class ActivateNextLevel : MonoBehaviour {
	public GameObject nextScene;
	public Transform spawnPos;
	GameObject spawnedText ;
	public Transform theCanvas;
	public bool maySpawn;
	public bool mayGo;

	void OnTriggerStay (Collider collision){
		if(collision.transform.tag == "NextLevel"){
			if(maySpawn){
				spawnedText = (GameObject) Instantiate (nextScene,spawnPos.position,Quaternion.identity);
				print (spawnedText);
				spawnedText.transform.SetParent(theCanvas);
				maySpawn = false;
			}
			if(Input.GetButtonDown("Interact")|| mayGo){
					collision.transform.GetComponent<LoadNextLevel>().GoToNextLevel();
			}
		}
	}
}
