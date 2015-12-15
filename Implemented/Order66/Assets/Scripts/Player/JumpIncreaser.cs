using UnityEngine;
using System.Collections;

public class JumpIncreaser : MonoBehaviour {
	public GameObject parentObject;
	public int jumpIncreasal;
	
	public void Awake(){
		parentObject.GetComponent<Movement> ().jumpHeight += jumpIncreasal;
	}
}
