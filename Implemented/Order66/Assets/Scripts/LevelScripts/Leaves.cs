using UnityEngine;
using System.Collections;

public class Leaves : MonoBehaviour {
	public 	float 		leafSpeed;
	public 	Rigidbody 	rb;
	public 	float 		forDisRay;
	bool 	mayGo 		= false;
	public	bool 		moveForward;
	public 	Vector3 	moveDir;
	public 	Transform 	player;
	bool 	oneTime 	= true;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if(moveForward && oneTime){
			LeavesGo ();
			//moveForward = false;
		//	oneTime = false;
		}
		// fix dit later
		if(moveForward){
			LeavesGo();
		}
		if(mayGo){
			LeavesDrop ();
		}
	}

	void LeavesGo (){
		if(oneTime){
			moveDir = transform.position - player.position;
			moveDir.y = 0;
			oneTime = false;
		}
		transform.Translate(moveDir * leafSpeed * Time.deltaTime);
		mayGo = true;
	}

	void LeavesDrop (){
		if(Physics.Raycast(transform.position,moveDir,forDisRay)){
			rb.useGravity = true;
			transform.DetachChildren();
		}
		if(mayGo){
			if(Physics.Raycast(transform.position,-transform.up,forDisRay)){
				rb.useGravity = true;
				transform.DetachChildren();
			}
			else{
				forDisRay += 0.1f * Time.deltaTime;
			}
		}
	}
}
