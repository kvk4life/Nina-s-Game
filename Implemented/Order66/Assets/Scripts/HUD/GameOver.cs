using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	//Dit script moet de hele game bedekken met een gameover plaatje en na een aantal secondes
	//Weg vagen met als de respawnde pc in beeld.
	public bool gameOver;

	public float fader;

	public GameObject GameOverScreen;

	public void Update(){
		Fading ();
		ColorTest ();
	}

	public void GameOverSwitch(){
		GameOverScreen.SetActive (gameOver);
	}

	public void Fading(){
		if (gameOver) {
			fader -= 1 * Time.deltaTime / 5;
		}
	}

	public void ColorTest(){
		GameOverScreen.GetComponent<CanvasGroup> ().alpha = fader;
	}
}
