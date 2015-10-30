using UnityEngine;
using System.Collections;

public class Presentation : MonoBehaviour {
	//Input list voor teleporteren naar spawnpoints: ("T" + int);
	//Input list voor immortality: ("T" + "I");
	//Input list voor superendurance: ("T" + "E");

	public int spawnNr;
	public Transform[] spawnPos;
	public bool immortality;
	public bool superEndurance;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		TeleportCheck ();
		ImmortalCheck ();
		EnduranceCheck ();
	}

	public void TeleportCheck(){
		if(Input.GetButton ("Teleport")){
			if(Input.GetButtonDown ("1")){
				Teleporting(0);
			}
			if(Input.GetButtonDown ("2")){
				Teleporting(1);
			}
			if(Input.GetButtonDown ("3")){
				Teleporting(2);
			}
			if(Input.GetButtonDown ("4")){
				Teleporting(3);
			}
			if(Input.GetButtonDown ("5")){
				Teleporting(4);
			}
			if(Input.GetButtonDown ("6")){
				Teleporting(5);
			}
		}
	}

	public int Teleporting(int teleportValue){
		transform.position = spawnPos [teleportValue].position;
		return(teleportValue);
	}

	public void ImmortalCheck(){
		if(Input.GetButtonDown ("Immortal")){
			immortality = !immortality;
			GetComponent<PlayerHealth>().immortal = immortality;
		}
	}

	public void EnduranceCheck(){
		superEndurance = !superEndurance;
		GetComponent<Stamina> ().superEndurance = superEndurance;
	}
}
