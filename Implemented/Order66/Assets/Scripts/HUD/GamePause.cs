using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject controlPanel;
	public GameObject optionsMenu;
	public GameObject loadMenu;

	void Update (){
		if(Input.GetButtonDown("Esc")){
			Time.timeScale = 0f;
			pauseMenu.SetActive(true);
		}                                 
	}
	public void  UnPause () {
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}
	public void BackToMainMenu (){
		Application.LoadLevel ("Main Menu");
		Time.timeScale = 1f;
	}

	public void Controls (){
		controlPanel.SetActive (true);
		pauseMenu.SetActive (false);
	}

	public void Return (){
		optionsMenu.SetActive (false);
		loadMenu.SetActive (false);
		controlPanel.SetActive (false);
		pauseMenu.SetActive (true);
	}

	public void Options (){
		optionsMenu.SetActive (true);
		pauseMenu.SetActive (false);
	}

	public void LoadGames (){
		pauseMenu.SetActive(false);
		loadMenu.SetActive(true);
	}
}

