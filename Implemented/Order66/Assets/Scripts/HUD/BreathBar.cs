using UnityEngine;
using System.Collections;

public class BreathBar : MonoBehaviour {
	public GameObject player;
	
	float breath;
	float maxBreath;
	public float breathHeight;
	public float breathWidth;
	float breathBarWidth;
	float breathBarHeight;
	float fadeTimer;
	public float setFadeTimer;
	
	public void Update () {
		BreathLink ();
		BreathImgScaler();
		FadeTimer ();
	}
	
	public void BreathLink(){
		breath = player.GetComponent<BreathHolding> ().curBreath;
		maxBreath = player.GetComponent<BreathHolding> ().maxBreath;
	}
	
	public void BreathImgScaler(){
		breathBarWidth = breath/maxBreath * breathWidth;
		breathBarHeight = breathHeight;
		GetComponent<RectTransform> ().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, breathBarWidth);
		GetComponent<RectTransform> ().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, breathBarHeight); 
	}

	public void FadeTimer(){
		if (breath < maxBreath) {
			GetComponent<CanvasGroup>().alpha = 1;
			fadeTimer = setFadeTimer;
		}
		else {
			fadeTimer -= Time.deltaTime;
			if(fadeTimer < 1){
				GetComponent<CanvasGroup>().alpha = 0;
			}
		}
	}
}
