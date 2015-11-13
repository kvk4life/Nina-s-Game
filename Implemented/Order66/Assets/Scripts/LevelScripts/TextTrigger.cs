using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {
	public int balloonTextMin;
	public int balloonTextMax;
	private GameObject menu;
	
	public void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player"){
			menu = GameObject.Find ("GameManager");
			menu.GetComponent<ThoughtBalloons>().triggerBalloons = true;
			menu.GetComponent<ThoughtBalloons>().curBalloonText = balloonTextMin;
			menu.GetComponent<ThoughtBalloons>().curBalloonTextMax = balloonTextMax;
		}
	}
}
