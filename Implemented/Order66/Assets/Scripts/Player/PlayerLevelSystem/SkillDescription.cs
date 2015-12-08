using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillDescription : MonoBehaviour {
	public enum skillText{
		Melee,
		Shield,
		Stamina,
		Health,
		Accept,
		Decline,
		Empty
	}

	public skillText description;
	public GameObject textField;
	public Text targetText;
	public string meleeText;
	public string shieldText;
	public string staminaText;
	public string healthText;
	public string acceptText;
	public string declineText;
	private string emptyText;
	
	void Start () {
		emptyText = "Add here your skillpoints";
		EmptySwitch ();
	}

	public void MeleeSwitch(){
		description = skillText.Melee;
		TextSwitch ();
	}

	public void ShieldSwitch(){
		description = skillText.Shield;
		TextSwitch ();
	}

	public void StaminaSwitch(){
		description = skillText.Stamina;
		TextSwitch ();
	}

	public void HealthSwitch(){
		description = skillText.Health;
		TextSwitch ();
	}

	public void AcceptButton(){
		description = skillText.Accept;
		TextSwitch ();
	}

	public void DeclineButton(){
		description = skillText.Decline;
		TextSwitch ();
	}

	public void EmptySwitch (){
		description = skillText.Empty;
		TextSwitch ();
	}

	public void TextSwitch () {
		switch (description) {
			case skillText.Empty:
			targetText.text = emptyText;
			break;
			case skillText.Melee:
			targetText.text = meleeText;
			break;
			case skillText.Shield:
			targetText.text = shieldText;
			break;
			case skillText.Stamina:
			targetText.text = staminaText;
			break;
			case skillText.Accept:
			targetText.text = acceptText;
			break;
			case skillText.Decline:
			targetText.text = declineText;
			break;
			case skillText.Health:
			targetText.text = healthText;
			break;
		}
	}
}
