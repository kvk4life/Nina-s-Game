using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {
	public float stamina;
	public float maxStamina;
	float minStamina;
	public float staminaRegen;
	public float regenRate;
	float nextRegen;
	public float blockBonusPenalty;
	public bool superEndurance;
	public bool mayBlock;
	
	public void Start(){
		minStamina = 0;
		stamina = maxStamina;
	}
	
	public void Update(){
		if (!superEndurance) {
			if (Input.GetButton ("Fire1")) {
				StaminaReduction (25);
			}
		}
		Regenerate ();
		Stabilizer ();
	}
	
	public float StaminaReduction(float reduction){
		stamina -= reduction;
		return stamina;
	}
	
	public void Regenerate(){
		if (stamina < maxStamina && !GetComponent<Defense>().blocken) {
			if (Time.time > regenRate + nextRegen) {
				stamina += staminaRegen;
				nextRegen = Time.time;
			}
		}
		else if(stamina < maxStamina && GetComponent<Defense>().blocken && mayBlock){
			if (Time.time > regenRate + nextRegen) {
				stamina += staminaRegen / blockBonusPenalty;
				nextRegen = Time.time;
			}
		}
	}
	
	public void Stabilizer(){
		if (stamina > maxStamina) {
			stamina = maxStamina;
		}
		if(stamina < minStamina + 1){
			stamina = minStamina;
		}
	}
}
