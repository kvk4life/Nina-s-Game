using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	public Transform[] checkPoints;
	public int curCheckPoint;
	public GameObject player;

	public int SetCheckPoint(int checkedPoint){
		curCheckPoint = checkedPoint;
		return curCheckPoint;
	}

	public void Respawning(){
		player.transform.position = checkPoints [curCheckPoint].position;
		player.transform.rotation = checkPoints [curCheckPoint].rotation;
		player.GetComponent<PlayerHealth> ().Respawned ();
	}
}
