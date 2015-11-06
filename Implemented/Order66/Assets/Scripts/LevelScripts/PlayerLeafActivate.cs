using UnityEngine;
using System.Collections;

public class PlayerLeafActivate : MonoBehaviour {
	public float disRay;
	public RaycastHit rayHit;

	public void ActiveLeave (RaycastHit trigger){
		if(trigger.transform.tag == "Blaadje"){
			trigger.transform.GetComponent<Leaves>().moveForward = true;
			transform.SetParent(trigger.transform,false);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}