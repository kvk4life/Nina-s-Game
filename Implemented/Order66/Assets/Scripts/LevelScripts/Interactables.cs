using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Interactables : MonoBehaviour {
	public List<Transform> madeliefjesArr = new List<Transform>();
	public int nextFlower;
	public float healthPack;
	private GameObject shownText;
	public GameObject madeliefjesText;
	public GameObject healthPackText;
	public GameObject naaldText;
	public GameObject shieldText;
	public GameObject springText;
	public GameObject SpringObj;
	public Transform springSpawnPos;
	public GameObject shield;
	public Transform spawnPos;
    public Transform theCanvas;
	private bool maySpawn = true;
	public Text madeliefjesCountText;
	GameObject interactableObject;

	void OnTriggerStay(Collider collision) {
		if (collision.transform.tag == "Madeliefje") {
			interactableObject = collision.gameObject;
			Madeliefjes();
		}
		if (collision.transform.tag == "HealthPack") {
			interactableObject = collision.gameObject;
			HealthPacks();
		}
		if (collision.transform.tag == "Needle") {
			interactableObject = collision.gameObject;
			Needle();
		}
		if (collision.transform.tag == "Shield"){
			interactableObject = collision.gameObject;
			Shield();
		}
		if (collision.transform.tag == "Spring"){
			interactableObject = collision.gameObject;
			Spring();
		}

	}

	void Update() {
		if (Input.GetButtonDown("Interact")) {
			Interact();
		}
    }
	
	void Interact() {
		if(interactableObject!= null) {
			switch (interactableObject.tag) {
				case "Madeliefje":
					SetMadeliefjes();
					break;
				case "HealthPack":
					SetHealthPack();
					break;
				case "Naald":
					SetNeedle();
					break;
				case "Shield":
					SetShield();
					break;
				case "Spring":
					SetSpring();
					break;
			}
		}
		if (interactableObject != null) {
			Destroy(interactableObject);
		}
		if(shownText != null) {
			Destroy(shownText);
		}
	}

	void Spring (){
		if (maySpawn) {
			shownText = (GameObject)Instantiate(springText, spawnPos.position, Quaternion.identity);
			shownText.transform.SetParent(theCanvas);
			maySpawn = false;
			
		}
	}

	void SetSpring (){
		SpringObj.gameObject.SetActive (true);
		GetComponent<Movement> ().mayJump = true;
	}

	void Madeliefjes() {
		if (maySpawn) {
			shownText = (GameObject)Instantiate(madeliefjesText, spawnPos.position, Quaternion.identity);
			shownText.transform.SetParent(theCanvas);
			maySpawn = false;

		}
	}

	void SetMadeliefjes() {
		madeliefjesArr[nextFlower].gameObject.SetActive(true);
		nextFlower++;
		madeliefjesCountText.text = nextFlower.ToString();
	}

	void HealthPacks() {
		if (maySpawn) {
			shownText = (GameObject)Instantiate(healthPackText, spawnPos.position, Quaternion.identity);
			shownText.transform.SetParent(theCanvas);
			maySpawn = false;
		}
	}

	void SetHealthPack() {
		gameObject.GetComponent<PlayerHealth>().Heal(healthPack);
	}

	void SetNeedle() {
		if (maySpawn) {
			shownText = (GameObject)Instantiate(naaldText, spawnPos.position, Quaternion.identity);
			shownText.transform.SetParent(theCanvas);
			maySpawn = false;
		}
	}

	void Needle (){
		//heeft naald
	}

	void Shield() {
		if (maySpawn) {
			shownText = (GameObject)Instantiate(shieldText, spawnPos.position, Quaternion.identity);
			shownText.transform.SetParent(theCanvas);
			maySpawn = false;
		}
	}

	void SetShield() {
		shield.gameObject.SetActive(true);
	}

	void OnTriggerExit (){
		if(shownText != null){
			Destroy(shownText);
		}
		maySpawn = true;
	}
}
