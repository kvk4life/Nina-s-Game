using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public int CheckPointNumber;

	public void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player"){
			GameObject.Find ("GameMng").GetComponent<Respawn>().SetCheckPoint(CheckPointNumber);
		}
	}
}
