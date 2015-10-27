using UnityEngine;
using System.Collections;

public class SpiderWeb : MonoBehaviour {
	private RaycastHit hit;
	public float rayDis;
	public Rigidbody rb;
	public float jumpHeight;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, rayDis)){
			if(hit.transform.tag == "CobWeb"){
				rb.velocity = new Vector3 (0, jumpHeight, 0);
			}
		}
	}
}
	/*
	void OnCollisionEnter (Collision player){
		if(player.transform.tag == "Player"){
			rb = player.gameObject.GetComponent<Rigidbody>();
			rb.velocity = new Vector3 (0, jumpHeight, 0);
		}
	}
}
*/