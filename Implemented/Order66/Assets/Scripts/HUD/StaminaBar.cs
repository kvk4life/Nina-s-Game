using UnityEngine;
using System.Collections;

public class StaminaBar : MonoBehaviour {
	public GameObject player;

	float stamina;
	float maxStamina;
	public float staminaHeight;
	public float staminaWidth;
	float staminaBarWidth;
	float staminaBarHeight;

	public void Update () {
		StaminaLink ();
		StaminaImgScaler();
	}

	public void StaminaLink(){
		stamina = player.GetComponent<Stamina> ().stamina;
		maxStamina = player.GetComponent<Stamina> ().maxStamina;
	}
	
	public void StaminaImgScaler(){
		staminaBarWidth = stamina/maxStamina * staminaWidth;
		staminaBarHeight = staminaHeight;
		GetComponent<RectTransform> ().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, staminaBarWidth);
		GetComponent<RectTransform> ().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, staminaBarHeight); 
	}
}
