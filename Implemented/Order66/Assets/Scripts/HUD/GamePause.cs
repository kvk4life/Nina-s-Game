using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {

	void Update (){

	}
	public void ResumeButton(){
		GetComponent<HUDControl> ().SwitchHudState (HUDControl.HudState.Play);
	}
	public void Pause(){
		GetComponent<HUDControl> ().SwitchHudState (HUDControl.HudState.PauseMenu);
	}
	public void BackToMainMenu (){
		Application.LoadLevel ("Main Menu");
	}

	public void Controls (){
		GetComponent<HUDControl> ().SwitchHudState (HUDControl.HudState.ControlMenu);
	}

	public void Return (){
		GetComponent<HUDControl> ().SwitchHudState (HUDControl.HudState.PauseMenu);
	}

	public void Options (){
		GetComponent<HUDControl> ().SwitchHudState (HUDControl.HudState.OptionMenu);
	}

	public void LoadGames (){ 
		GetComponent<HUDControl> ().SwitchHudState (HUDControl.HudState.LoadMenu);
	}
}

