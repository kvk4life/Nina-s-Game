using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {
	public int balloonTextMin;
	public int balloonTextMax;
	private GameObject subtitleHolder;
	
	public void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player"){
			subtitleHolder = GameObject.Find ("SubtitleMng");
			subtitleHolder.GetComponent<Subtitles>().triggerSubtitles = true;
			subtitleHolder.GetComponent<Subtitles>().curBalloonText = balloonTextMin;
			subtitleHolder.GetComponent<Subtitles>().curBalloonTextMax = balloonTextMax;
		}
	}
}
