using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {
	//Dit is de verzamling van alle scripts van de buttons van de menu's
	//Dit is ook tevens het main menu script die wordt gedeeld via GitHub

	public GameObject cainNu;
	public GameObject toadNu;
	public GameObject optionNu;

	//De load game button kan niet geselecteerd worden als er geen save is
	//Saves worden aangemaakt en geupdate bij elke checkpoint
	//De checkpoints saven op 1 slot, tenzij de speler een new game begint
	//In dit geval worden de saves op de volgende slot gezet
	//Zijn alle slots vol moet de speler handmatig 1 of meerder save games verwijderen
	public void LoadSwitcher(){
		cainNu.SetActive (false);
		toadNu.SetActive (true);
	}

	public void OptionSwitchter(){
		cainNu.SetActive (false);
		optionNu.SetActive (true);
	}
	
	public void ReturnSwitcher(){
		toadNu.SetActive (false);
		optionNu.SetActive (false);
		cainNu.SetActive (true);
	}

	public void NeueSpiel(){
		Application.LoadLevel ("Boomstronk");
	}

	public void SpielEnde(){
		Application.Quit();
	}
}
