using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public bool gameOver;
	public float fader;
	float startFader;
	public float countDownToFade;
	float countDownToFadeReset;
	public float countDownSpeed;
	public float fadeSpeed;
	public GameObject GameOverScreen;

	public void Start(){
		startFader = fader;
		countDownToFadeReset = countDownToFade;
	}
	
	public void Update(){
		Fading ();
		ColorTest ();
	}
	
	public void GameOverSwitch(){
		fader = startFader;
		countDownToFade = countDownToFadeReset;
	}
	
	public void Fading(){
		if (gameOver && countDownToFade > 0) {
			countDownToFade -= Time.deltaTime / countDownSpeed;
		}
		else if(countDownToFade <= 0){
			if(countDownToFade <= 0){
				fader -= Time.deltaTime / fadeSpeed;
			}
		}
		if(fader <= 0){
			gameOver = false;
			GameOverSwitch();
		}
	}
	
	public void ColorTest(){
		GameOverScreen.GetComponent<CanvasGroup> ().alpha = fader;
	}
}