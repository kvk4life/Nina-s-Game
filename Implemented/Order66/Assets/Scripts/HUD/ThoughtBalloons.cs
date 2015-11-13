using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThoughtBalloons : MonoBehaviour {
	//Dit script moet denkwolkjes maken dat vanaf Nina's hoofd komt
	//Vervolgens moet er tekst in komen dat de speler hints en tips geeft
	//De denkwolkjes moeten pas komen als ze getriggered worden
	public bool triggerBalloons;
	public bool deactivate;
	public bool switchText;
	public string[] balloonText;
	public int curBalloonText;
	public int curBalloonTextMax;
	private int balloonCount;
	public Text finalBalloonText;
	public GameObject[] thoughtBalloons;
	public float[] balloonFader;
	public float faderSpeed;
	private float switchCountDownReset;
	public float switchCountDown;
	public float deactivationCountDown;
	private float deactivationCountDownReset;
	public float nextBalloonTextCountDown;
	private float nextBalloonTextCountDownReset;
	
	public void Start(){
		switchCountDownReset = switchCountDown;
		deactivationCountDownReset = deactivationCountDown;
		nextBalloonTextCountDownReset = nextBalloonTextCountDown;
	}

	public void Update(){
		if(triggerBalloons){
			TextSwapper();
			BalloonActivation();
			BalloonDeactivationCountDown();
		}
	}

	public void TextSwapper(){
		if(curBalloonText < balloonText.Length){
			finalBalloonText.text = balloonText [curBalloonText];
		}
		if(curBalloonText == curBalloonTextMax){
			deactivate = true;
		}
		if(nextBalloonTextCountDown > 0 && switchText){
			nextBalloonTextCountDown -= Time.deltaTime;
		}
		if (nextBalloonTextCountDown < 0) {
			curBalloonText++;
			nextBalloonTextCountDown = nextBalloonTextCountDownReset;
		}
	}

	public void BalloonActivation(){
		thoughtBalloons[balloonCount].GetComponent<CanvasGroup>().alpha = balloonFader[balloonCount];
		if (switchCountDown > 0 && balloonCount < thoughtBalloons.Length) {
			switchCountDown -= Time.deltaTime;
		}
		if(switchCountDown < 0) {
			balloonFader[balloonCount] += Time.deltaTime/faderSpeed;
			if(balloonFader[balloonCount] > 1){
				balloonCount ++;
				switchCountDown = switchCountDownReset;
			}
		}
		if(balloonCount == thoughtBalloons.Length){
			balloonCount = thoughtBalloons.Length - 1;
			switchText = true;
		}
	}

	public void BalloonDeactivation(){
		for(int i = 0; i < balloonFader.Length; i++){
			thoughtBalloons[i].GetComponent<CanvasGroup>().alpha = 0;
		}
		deactivationCountDown = deactivationCountDownReset;
		switchCountDown = switchCountDownReset;
		balloonCount = 0;
		curBalloonText = 0;
		deactivate = false;
		switchText = false;
		triggerBalloons = false;
	}

	public void BalloonDeactivationCountDown(){
		if(deactivate){
			deactivationCountDown -= Time.deltaTime;
			if(deactivationCountDown <= 0){
				BalloonDeactivation();
			}
		}
	}

	public void CancelBalloons(){
		print ("Canceled!");
		BalloonDeactivation ();
	}
}
