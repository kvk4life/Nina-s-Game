using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	//Dit script moet de hele game bedekken met een gameover plaatje en na een aantal secondes
	//Weg vagen met als de respawnde pc in beeld.
	public bool gameOver;

	public float fader;

	public GameObject GameOverScreen;
	void start (){
		GameOverScreen.SetActive (false);
	}

	public void Update(){
		Fading ();
		ColorTest ();
	}

	public void GameOverSwitch(){
		gameOver = true;
		GameOverScreen.SetActive (true);
	}

	public void Fading(){
		if (gameOver) {
			fader -= 1 * Time.deltaTime / 5;
		}
	}

	public void ColorTest(){
		if (gameOver) {
			GameOverScreen.GetComponent<CanvasGroup> ().alpha = fader;
		}
	}
	public void respawnButton (){
		GetComponent<Respawn> ().Respawning ();
		GameOverScreen.SetActive(false);
		gameOver = false;
	}
}
