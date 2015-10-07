using UnityEngine;
using System.Collections;

public class Defense : MonoBehaviour {
	public bool blocken;

	public float minStaminaReq;

	public void Update(){
		Blocking ();
	}

	public void Blocking(){
		float myStamina = GetComponent<Stamina> ().stamina;
		if (Input.GetButton ("Fire2") && myStamina > minStaminaReq) {
			blocken = true;
		}
		else {
			blocken = false;
		}
	}
}
