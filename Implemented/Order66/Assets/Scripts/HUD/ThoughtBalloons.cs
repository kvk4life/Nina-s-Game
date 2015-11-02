using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThoughtBalloons : MonoBehaviour {
	//Dit script moet denkwolkjes maken dat vanaf Nina's hoofd komt
	//Vervolgens moet er tekst in komen dat de speler hints en tips geeft
	//De denkwolkjes moeten pas komen als ze getriggered worden
	public bool triggerBalloons;
	public string[] balloonText;
	public int curBalloonText;
	private int balloonCount;
	public Text finalBalloonText;
	public GameObject[] thoughtBalloons;
	public GameObject thoughtBalloonsParent;
	public float[] balloonFader;
	public float faderSpeed;
	private float switchCountDownReset;
	public float switchCountDown;
	public float deactivationCountDown;
	private float deactivationCountDownReset;
	private float balloonDuration;
	public float maxBalloonDuration;
	
	public void Start(){
		switchCountDownReset = switchCountDown;
		deactivationCountDownReset = deactivationCountDown;
	}

	public void Update(){
		if(triggerBalloons){
			TextSwapper();
			BalloonActivation();
		}
	}

	public void TextSwapper(){
		finalBalloonText.text = balloonText [curBalloonText];
	}

	public void BalloonActivation(){
		thoughtBalloons[balloonCount].GetComponent<CanvasGroup>().alpha = balloonFader[balloonCount];
		if (switchCountDown > 0 && balloonCount < thoughtBalloons.Length) {
			switchCountDown -= Time.deltaTime;
		}
		else if(balloonCount == thoughtBalloons.Length){
			BalloonDeactivationCountDown();
		}
		if(switchCountDown < 0) {
			balloonFader[balloonCount] += Time.deltaTime/faderSpeed;
			if(balloonFader[balloonCount] > 1){
				print ("balloonCount = " + balloonCount);
				balloonCount ++;
				switchCountDown = switchCountDownReset;
			}
		}
	}

	public void BalloonDeactivation(){
		triggerBalloons = false;
		balloonCount = 0;
		for(int i = 0; i < balloonFader.Length; i++){
			balloonFader[i] = 0;
		}
		deactivationCountDown = deactivationCountDownReset;
	}

	public void BalloonDeactivationCountDown(){
		deactivationCountDown -= Time.deltaTime;
		if(deactivationCountDown < 0){
			BalloonDeactivation();
		}
	}
}
