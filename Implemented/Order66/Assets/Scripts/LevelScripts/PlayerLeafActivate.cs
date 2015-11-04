using UnityEngine;
using System.Collections;

public class PlayerLeafActivate : MonoBehaviour {
	public float disRay;
	public RaycastHit rayHit;

	void Update () {
//		if(Physics.Raycast(transform.position,-transform.up,out rayHit,disRay)){
//			if(rayHit.transform.tag == "Blaadje"){
//				transform.SetParent(rayHit.transform,false);
//				rayHit.transform.GetComponent<Leaves>().moveForward = true;
//				GetComponent<Rigidbody>().velocity = Vector3.zero;
//			}
//		}
	}

	public void ActiveLeave (RaycastHit trigger){
		if(trigger.transform.tag == "Blaadje"){
			trigger.transform.GetComponent<Leaves>().moveForward = true;
			transform.SetParent(trigger.transform,false);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}