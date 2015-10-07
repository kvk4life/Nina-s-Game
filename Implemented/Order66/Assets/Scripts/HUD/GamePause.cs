using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
	public GameObject pauseMenu;

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
}

