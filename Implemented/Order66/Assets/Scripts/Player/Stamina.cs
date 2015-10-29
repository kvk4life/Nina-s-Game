using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {
	public float stamina;
	public float maxStamina;
	float minStamina;
	public float staminaRegen;
	public float regenRate;
	float nextRegen;

	public void Start(){
		minStamina = 0;
		stamina = maxStamina;
	}

	public void Update(){
		Regenerate ();
		Stabilizer ();
		if (GetComponent<Defense> ().blocken) {
			StaminaReduction(GetComponent<Defense>().minStaminaReq);
		}
	}

	public float StaminaReduction(float reduction){
		stamina -= reduction*Time.deltaTime;
		return stamina;
	}

	public void Regenerate(){
		if (stamina < maxStamina) {
			if (Time.time > regenRate + nextRegen) {
				stamina += staminaRegen;
				nextRegen = Time.time;
			}
		}
	}

	public void Stabilizer(){
		if (stamina > maxStamina) {
			stamina = maxStamina;
		}
		if(stamina < minStamina){
			stamina = minStamina;
		}
	}
}
