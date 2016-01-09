using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour {
	//Dit script moet denkwolkjes maken dat vanaf Nina's hoofd komt
	//Vervolgens moet er tekst in komen dat de speler hints en tips geeft
	//De denkwolkjes moeten pas komen als ze getriggered worden
	public GameObject subtitle;
	public Text displayedBalloonText;
	public bool triggerSubtitles;
	public bool deactivate;
	public bool switchText;
	private float balloonFader;
	public float faderSpeed;
	public float deactivationCountDown;
	private float deactivationCountDownReset;
	public float nextBalloonTextCountDown;
	private float nextBalloonTextCountDownReset;
	public int curBalloonText;
	public int curBalloonTextMax;
	public string[] balloonText;
	
	public void Start(){
		subtitle.GetComponent<CanvasGroup>().alpha = balloonFader;
		deactivationCountDownReset = deactivationCountDown;
		nextBalloonTextCountDownReset = nextBalloonTextCountDown;
	}
	
	public void Update(){
		if(triggerSubtitles){
			TextSwapper();
			BalloonActivation();
			BalloonDeactivationCountDown();
		}
	}
	
	public void TextSwapper(){
		if(curBalloonText < balloonText.Length){
			displayedBalloonText.text = balloonText [curBalloonText];
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
		subtitle.GetComponent<CanvasGroup>().alpha = balloonFader;
		balloonFader += Time.deltaTime/faderSpeed;
		if(balloonFader > 1){
			switchText = true;
		}
	}
	
	public void BalloonDeactivation(){
		subtitle.GetComponent<CanvasGroup>().alpha = 0;
		deactivationCountDown = deactivationCountDownReset;
		curBalloonText = 0;
		deactivate = false;
		switchText = false;
		triggerSubtitles = false;
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
