using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {
	public static float pcLevel;
	public float startGivingSkillPoints;
	public float pcLevelMultiplier;
	public float maxLevel;
	private float curExp;
	public float startExp;
	private float curReqExp;
	private float prevReqExp;
	public float expRectWidth;
	public float expProgress;
	public int skillPoint;
	public Text curLevelText;
	public Text expPercentage;
	public RectTransform expBar;

	public void Start(){
		expRectWidth = expBar.rect.width;
		if(pcLevel == 0){
			LeveledUp();
			curReqExp = startExp;
		}
	}
	public void Update(){
		ExpBar ();
	}

	public void RequiredExp(){
		prevReqExp = curReqExp;
		curReqExp = curReqExp + (pcLevel * pcLevel);
	}

	public void LeveledUp(){
		if(pcLevel > startGivingSkillPoints && pcLevel < maxLevel ){
			GetComponent<SkillTree> ().AddToPool (skillPoint);
		}
		pcLevel += pcLevelMultiplier;
		RequiredExp ();
		TextChecker ();
		if(curExp > curReqExp){
			RemainderExp(curExp);
		}
	}

	public float GetExp(float gainedExp){
		curExp += gainedExp;
		if(curExp > curReqExp && pcLevel < maxLevel){
			LeveledUp();
		}
		if(pcLevel >= maxLevel){
			pcLevel = maxLevel;
			curExp = curReqExp;
			TextChecker ();
		}
		return curExp;
	}

	public float RemainderExp(float remainingExp){
		if(curExp > curReqExp){
			LeveledUp();
		}
		return curExp;
	}

	public void ExpBar(){
		float newTotal = curReqExp - prevReqExp;
		float newPercentage = curExp - prevReqExp;
		expProgress = newPercentage/ newTotal * 100;
		float expBarWidth = newPercentage / newTotal * expRectWidth;
		expBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, expBarWidth);
		expPercentage.text = expProgress.ToString ("F1") + ("%");
	}

	public void TextChecker(){
		curLevelText.text = pcLevel.ToString();
	}
}
