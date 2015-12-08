using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public bool gameOver;
	public float fader;
	float startFader;
	public float countDownToFade;
	float countDownToFadeReset;
	public float fadeSpeed;
	public GameObject GameOverScreen;
	
	public void Start(){
		startFader = fader;
		fader = 0;
		countDownToFadeReset = countDownToFade;
	}
	
	public void Update(){
		Fading ();
		ColorTest ();
	}
	
	public void Fading(){
		if (gameOver && countDownToFade > 0) {
			countDownToFade -= Time.deltaTime;
			fader = startFader;
		}
		else if (countDownToFade <= 0) {
			fader -= Time.deltaTime / fadeSpeed;
			GetComponent<Respawn>().Respawning();
		}
		if (fader <= 0) {
			gameOver = false;
			countDownToFade = countDownToFadeReset;
		}
		GameOverScreen.SetActive(gameOver);
	}
	
	public void ColorTest(){
		GameOverScreen.GetComponent<CanvasGroup> ().alpha = fader;
	}
}
