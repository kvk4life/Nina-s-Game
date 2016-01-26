using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {
	private AudioSource leSource;
	public AudioClip myClip;
	public int balloonTextMin;
	public int balloonTextMax;
	private GameObject subtitleHolder;

	void Start(){
		leSource = GameObject.FindWithTag ("Player").GetComponent<AudioSource>();
	}
	
	public void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player"){
			subtitleHolder = GameObject.Find ("SubtitleMng");
			ClipChecker();
			subtitleHolder.GetComponent<Subtitles>().triggerSubtitles = true;
			subtitleHolder.GetComponent<Subtitles>().curBalloonText = balloonTextMin;
			subtitleHolder.GetComponent<Subtitles>().curBalloonTextMax = balloonTextMax;
		}
	}

	void ClipChecker(){
		if (myClip != null) {
			leSource.PlayOneShot (myClip);
		}
		else {
			return;
		}
	}
}
