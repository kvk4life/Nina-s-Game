using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour {
	public GameObject player;
	public enum HudState{
		PauseMenu,
		OptionMenu,
		SkillsMenu,
		Play,
		GameOver,
		ControlMenu,
		LoadMenu
	}	
	public HudState hudState;
	public GameObject[] menus;

	public void Start(){
		if(Application.loadedLevelName == "Level 1"){
			SwitchHudState(HudState.Play);
		}
	}

	public void Update(){
		EscButton ();
		if(Input.GetButtonDown("Inventory")){
			ButtonSwitchSkillTree(true);
		}
	}

	public void ButtonSwitchSkillTree(bool withKey){
		if (hudState == HudState.SkillsMenu && !withKey) {
			player.GetComponent<SkillTree>().TempSkillRemoval();
			SwitchHudState (HudState.PauseMenu);
		} else if (hudState == HudState.SkillsMenu && withKey) {
			player.GetComponent<SkillTree>().TempSkillRemoval();
			SwitchHudState (HudState.Play);
		}
		else {
			SwitchHudState (HudState.SkillsMenu);
		}
	}

	public void SwitchHudState(HudState newState){
		hudState = newState;
		switch(hudState){
			case HudState.PauseMenu:
				SelectHudState("PauseMenu");	
			break;
			case HudState.OptionMenu:
				SelectHudState("OptionsPanel");	
			break;
			case HudState.SkillsMenu:
				SelectHudState("SkillTreeHud");	
			break;
			case HudState.Play:
				SelectHudState("PlayingHud");	
			break;
			case HudState.GameOver:
				SelectHudState("GameOverPanel");	
			break;
			case HudState.ControlMenu:
				SelectHudState("ControlPanel");	
			break;
			case HudState.LoadMenu:
				SelectHudState("LoadGame");	
			break;
		}
	}

	public void SelectHudState(string newState){
		for(int i = 0; i < menus.Length; i++){
			if(menus[i].name == newState){
				menus[i].SetActive(true);
				StateEffects(newState);
			}
			else{
				menus[i].SetActive(false);
			}
		}
	}

	public void StateEffects(string newEffect){
		if(newEffect != "PlayingHud"){
			Time.timeScale = 0f;
			Cursor.visible = true;
		}
		else{
			Time.timeScale = 1f;
			Cursor.visible = false;
		}
	}

	public void EscButton(){
		if(Input.GetButtonDown ("Esc")){
			if(hudState == HudState.Play){
				hudState = HudState.PauseMenu;
			}
			else{
				hudState = HudState.Play;
			}
			SwitchHudState(hudState);
		}
	}
}
