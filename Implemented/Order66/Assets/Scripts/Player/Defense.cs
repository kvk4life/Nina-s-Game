using UnityEngine;
using System.Collections;

public class Defense : MonoBehaviour {
	public bool blocken;
	public bool shieldMaxed;
	public float minStaminaReq;
	public int blockCount;
	public int maxBlockCount;
	public float blockHeal;

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
		GetComponent<Play_Animation> ().Gaurd (blocken);
	}

	public void BlockCounter(){
		if (blockCount < maxBlockCount) {
			blockCount++;
		}
		else {
			GetComponent<PlayerHealth>().Heal (blockHeal);
			blockCount = 0;
		}
	}
}
