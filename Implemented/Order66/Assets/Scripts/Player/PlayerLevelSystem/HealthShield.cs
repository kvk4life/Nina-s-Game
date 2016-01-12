using UnityEngine;
using System.Collections;

public class HealthShield : MonoBehaviour {
	public GameObject healthShield;
	public float timer;
	private float resetTimer;
	public bool healthBonus;

	public void Start(){
		resetTimer = timer;
		healthShield.GetComponent<CanvasGroup> ().alpha = GetComponent<PlayerHealth> ().healthShield;
	}

	public void Update(){
		if (healthBonus) {
			healthShield.GetComponent<CanvasGroup> ().alpha = GetComponent<PlayerHealth> ().healthShield;
			ShieldTimer ();
		}
	}

	public void ShieldTimer(){
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		else {
			ReactivateShield();
		}
	}

	public void ActivateShield(){
		healthBonus = true;
		ReactivateShield ();
	}

	public void ReactivateShield(){
		GetComponent<PlayerHealth> ().healthShield = 1;
	}

	public void TimerReset(){
		timer = resetTimer;
	}
}
