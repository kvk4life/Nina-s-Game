﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour {
	public GameObject skillMenu;
	public bool skillMenuSwitch;
	public Sprite filledExpBar;
	public Sprite tempExpBar;
	public Sprite emptyExpBar;
	public int skillPointPool;
	public int tempMeleePoints;
	public int tempShieldPoints;
	public int tempStaminaPoints;
	public int tempHealthPoints;
	public int meleePoints;
	public int shieldPoints;
	public int staminaPoints;
	public int healthPoints;
	public int maxBarPoints;
	public float barWidth;
	private float slotWidth;
	public float slotHeight;
	public float maxStaminaBonus;
	private float staminaRegenRate;
	public float minStaminaRegenBonus;
	public GameObject expSlotPrefab;
	public GameObject meleeSlotParent;
	public GameObject shieldSlotParent;
	public GameObject staminaSlotParent;
	public GameObject healthSlotParent;
	public List<GameObject> meleeSkillPoints;
	public List<GameObject> shieldSkillPoints;
	public List<GameObject> healthSkillPoints;
	public List<GameObject> staminaSkillPoints;
	public Canvas expCanvas;

	public void Start(){
		skillMenuSwitch = false;
		slotWidth = barWidth / maxBarPoints;
		meleeSkillPoints = new List<GameObject> ();
		shieldSkillPoints = new List<GameObject> ();
		staminaSkillPoints = new List<GameObject> ();
		healthSkillPoints = new List<GameObject> ();
		MeleeBarCreator ();
		ShieldBarCreator ();
		StaminaBarCreator ();
		HealthBarCreator ();
		staminaRegenRate = GetComponent<Stamina> ().regenRate;
	}

	public void Update(){
		SkillMenuSwitcher ();
	}

	public void SkillMenuSwitcher(){
		if(Input.GetButtonDown("SkillMenu")){
			skillMenuSwitch = !skillMenuSwitch;
		}
		skillMenu.SetActive(skillMenuSwitch);
	}

	public void FillTheBars(){
		for (int i = 0; i < maxBarPoints; i++) {
			if (i < meleePoints) {
				if (meleeSkillPoints [i].GetComponent<Image> ().sprite != filledExpBar) {
					meleeSkillPoints [i].GetComponent<Image> ().sprite = filledExpBar;
				}
			}
			if (i < staminaPoints) {
				if (staminaSkillPoints [i].GetComponent<Image> ().sprite != filledExpBar) {
					staminaSkillPoints [i].GetComponent<Image> ().sprite = filledExpBar;
				}
			}
			if (i < shieldPoints) {
				if (shieldSkillPoints [i].GetComponent<Image> ().sprite != filledExpBar) {
					shieldSkillPoints [i].GetComponent<Image> ().sprite = filledExpBar;
				}
			}
			if (i < healthPoints) {
				if (healthSkillPoints [i].GetComponent<Image> ().sprite != filledExpBar) {
					healthSkillPoints [i].GetComponent<Image> ().sprite = filledExpBar;
				}
			}
		}
	}

	public void AddToPool(int addedSkillPoint){
		skillPointPool += addedSkillPoint;
	}

	public void AddTempSkillPointMelee(){
		if(skillPointPool > 0 && tempMeleePoints < maxBarPoints){
			tempMeleePoints++;
			skillPointPool--;
			TempMeleeExpSlotAdded();
		}
	}

	public void AddTempSkillPointShield(){
		if(skillPointPool > 0 && tempShieldPoints < maxBarPoints){
			tempShieldPoints++;
			skillPointPool--;
			TempShieldExpSlotAdded();
		}
	}

	public void AddTempSkillPointStamina(){
		if(skillPointPool > 0 && tempShieldPoints < maxBarPoints){
			tempStaminaPoints++;
			skillPointPool--;
			TempStaminaExpSlotAdded();
		}
	}

	public void AddTempSkillPointHealth(){
		if(skillPointPool > 0 && tempShieldPoints < maxBarPoints){
			tempHealthPoints++;
			skillPointPool--;
			TempHealthExpSlotAdded();
		}
	}

	public void TempSkillRemoval(){
		for(int i = 0; i < maxBarPoints; i++){
			RemoveTempSkillPointMelee();
			RemoveTempSkillPointShield();
			RemoveTempSkillPointHealth();
			RemoveTempSkillPointStamina();
		}
	}

	public void RemoveTempSkillPointMelee(){
		if(tempMeleePoints > 0){
			tempMeleePoints--;
			skillPointPool++;
			TempMeleeExpSlotRemoval();
		}
	}

	public void RemoveTempSkillPointShield(){
		if(tempShieldPoints > 0){
			tempShieldPoints--;
			skillPointPool++;
			TempShieldExpSlotRemoval();
		}
	}

	public void RemoveTempSkillPointHealth(){
		if(tempHealthPoints > 0){
			tempHealthPoints--;
			skillPointPool++;
			TempHealthExpSlotRemoval();
		}
	}

	public void RemoveTempSkillPointStamina(){
		if(tempStaminaPoints > 0){
			tempStaminaPoints--;
			skillPointPool++;
			TempStaminaExpSlotRemoval();
		}
	}

	public void AddSkillPoints(){
		for(int i = 0; i < maxBarPoints; i++){
			if(tempMeleePoints > 0){
				tempMeleePoints--;
				meleePoints++;
			}
			else{
				MeleeExpSlotChecker();
			}
			if (tempShieldPoints > 0) {
				shieldPoints++;
				tempShieldPoints--;
			} else {
				ShieldExpSlotChecker();
			}
			if (tempHealthPoints > 0) {
				healthPoints++;
				tempHealthPoints--;
			} else {
				HealthExpSlotChecker();
			}
			if (tempStaminaPoints > 0) {
				staminaPoints++;
				tempStaminaPoints--;
			} 
			else {
				StaminaExpSlotChecker();
			}
		}
	}

	public void TempMeleeExpSlotAdded(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < meleePoints + tempMeleePoints){
				if(meleeSkillPoints[i].GetComponent<Image>().sprite == emptyExpBar){
					meleeSkillPoints[i].GetComponent<Image>().sprite = tempExpBar;
					//Extra Damage hier added
				}
			}
			else{
				break;
			}
		}
	}

	public void TempMeleeExpSlotRemoval(){
		for(int i = maxBarPoints - 1; i > -1; i--){
			if(meleeSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
				meleeSkillPoints[i].GetComponent<Image>().sprite = emptyExpBar;
				break;
			}
		}
	}

	public void TempShieldExpSlotRemoval(){
		for(int i = maxBarPoints - 1; i > -1; i--){
			if(shieldSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
				shieldSkillPoints[i].GetComponent<Image>().sprite = emptyExpBar;
				break;
			}
		}
	}

	public void TempStaminaExpSlotRemoval(){
		for(int i = maxBarPoints - 1; i > -1; i--){
			if(staminaSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
				staminaSkillPoints[i].GetComponent<Image>().sprite = emptyExpBar;
				break;
			}
		}
	}

	public void TempHealthExpSlotRemoval(){
		for(int i = maxBarPoints - 1; i > -1; i--){
			if(healthSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
				healthSkillPoints[i].GetComponent<Image>().sprite = emptyExpBar;
				break;
			}
		}
	}

	public void MeleeExpSlotChecker(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < meleePoints){
				if(meleeSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
					meleeSkillPoints[i].GetComponent<Image>().sprite = filledExpBar;
					//Extra Damage hier added
				}
			}
			else{
				break;
			}
			if(meleePoints == maxBarPoints){
				//Add de maxbonus effect hier
			}
		}
	}

	public void TempShieldExpSlotAdded(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < shieldPoints + tempShieldPoints){
				if(shieldSkillPoints[i].GetComponent<Image>().sprite == emptyExpBar){
					shieldSkillPoints[i].GetComponent<Image>().sprite = tempExpBar;
					//Extra Damage hier added
				}
			}
			else{
				break;
			}
		}
	}
	public void ShieldExpSlotChecker(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < shieldPoints){
				if(shieldSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
					shieldSkillPoints[i].GetComponent<Image>().sprite = filledExpBar;
					//Minder stamina kost hier added
				}
			}
			else{
				break;
			}
			if(shieldPoints == maxBarPoints){
				//Add de maxbonus effect hier
			}
		}
	}

	public void TempStaminaExpSlotAdded(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < staminaPoints + tempStaminaPoints){
				if(staminaSkillPoints[i].GetComponent<Image>().sprite == emptyExpBar){
					staminaSkillPoints[i].GetComponent<Image>().sprite = tempExpBar;
					//Extra Damage hier added
				}
			}
			else{
				break;
			}
		}
	}

	public void StaminaExpSlotChecker(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < staminaPoints){
				if(staminaSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
					staminaSkillPoints[i].GetComponent<Image>().sprite = filledExpBar;
					//Sneller stamina regen hier added
					float staminaBonus = maxStaminaBonus / maxBarPoints;
					GetComponent<Stamina>().maxStamina += staminaBonus;
					float staminaRegenBonus = (staminaRegenRate - minStaminaRegenBonus) / maxBarPoints;
					GetComponent<Stamina>().regenRate -= staminaRegenBonus;
				}
			}
			else{
				break;
			}
			if(staminaPoints == maxBarPoints){
				//Add de maxbonus effect hier
				GetComponent<Stamina>().mayBlock = true;
			}
		}
	}

	public void TempHealthExpSlotAdded(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < healthPoints + tempHealthPoints){
				if(healthSkillPoints[i].GetComponent<Image>().sprite == emptyExpBar){
					healthSkillPoints[i].GetComponent<Image>().sprite = tempExpBar;
					//Extra Damage hier added
				}
			}
			else{
				break;
			}
		}
	}

	public void HealthExpSlotChecker(){
		for(int i = 0; i < maxBarPoints; i++){
			if(i < healthPoints){
				if(healthSkillPoints[i].GetComponent<Image>().sprite == tempExpBar){
					healthSkillPoints[i].GetComponent<Image>().sprite = filledExpBar;
					//Extra health hier added
					GetComponent<PlayerHealth>().maxHealth++;
				}
			}
			else{
				break;
			}
			if(healthPoints == maxBarPoints){
				//Add de maxbonus effect hier

			}
		}
	}

	public void MeleeBarCreator(){
		for(int i = 0; i < maxBarPoints; i++){
			GameObject createdSlot = GameObject.Instantiate(expSlotPrefab);
			RectTransform slotRec = createdSlot.GetComponent<RectTransform>();
			createdSlot.name = "ExpMeleeSlot";
			createdSlot.transform.SetParent(meleeSlotParent.transform);
			slotRec.localPosition = new Vector3(i * slotWidth, 0, 0);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotWidth * expCanvas.scaleFactor);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotHeight * expCanvas.scaleFactor);
			meleeSkillPoints.Add(createdSlot);
		}
	}

	public void ShieldBarCreator(){
		for(int i = 0; i < maxBarPoints; i++){
			GameObject createdSlot = GameObject.Instantiate(expSlotPrefab);
			RectTransform slotRec = createdSlot.GetComponent<RectTransform>();
			createdSlot.name = "ExpShieldSlot";
			createdSlot.transform.SetParent(shieldSlotParent.transform);
			slotRec.localPosition = new Vector3(i * slotWidth, 0, 0);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotWidth * expCanvas.scaleFactor);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotHeight * expCanvas.scaleFactor);
			shieldSkillPoints.Add(createdSlot);
		}
	}

	public void StaminaBarCreator(){
		for(int i = 0; i < maxBarPoints; i++){
			GameObject createdSlot = GameObject.Instantiate(expSlotPrefab);
			RectTransform slotRec = createdSlot.GetComponent<RectTransform>();
			createdSlot.name = "ExpStaminaSlot";
			createdSlot.transform.SetParent(staminaSlotParent.transform);
			slotRec.localPosition = new Vector3(i * slotWidth, 0, 0);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotWidth * expCanvas.scaleFactor);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotHeight * expCanvas.scaleFactor);
			staminaSkillPoints.Add(createdSlot);
		}
	}

	public void HealthBarCreator(){
		for(int i = 0; i < maxBarPoints; i++){
			GameObject createdSlot = GameObject.Instantiate(expSlotPrefab);
			RectTransform slotRec = createdSlot.GetComponent<RectTransform>();
			createdSlot.name = "ExpHealthSlot";
			createdSlot.transform.SetParent(healthSlotParent.transform);
			slotRec.localPosition = new Vector3(i * slotWidth, 0, 0);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotWidth * expCanvas.scaleFactor);
			slotRec.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotHeight * expCanvas.scaleFactor);
			healthSkillPoints.Add(createdSlot);
		}
	}
}
