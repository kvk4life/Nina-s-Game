using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour { 
	public float moveSpeed;
	public float rotationSpeed;
	public float wallRayDis;
	public float jumpCheck;
	public bool mayMove;
	public Rigidbody rb;
	public int jumpCounter;
	public int jumpHeight;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		Rotation();
		if (Input.GetButtonDown ("Jump")) {
			Jump();
		}
		if (Physics.Raycast(transform.position, -Vector3.up, jumpCheck)){
			jumpCounter = 0;
		}
		if (mayMove) {
			Moving();
		}
		if (Physics.Raycast (transform.position, transform.forward, wallRayDis)){
			if(mayMove)	{
				mayMove = false;
			}
		}
		else{
			mayMove = true;
		}
	}

	void Moving() {
		float translation = Input.GetAxis("Vertical") * moveSpeed;
		translation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
	}

	void Jump (){
		if (jumpCounter < 1) 	{
			rb.velocity = new Vector3 (0, jumpHeight, 0);
			jumpCounter = 1;
		}
	}

	void Rotation() {
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		transform.Rotate(0, rotation, 0);
		rotation *= Time.deltaTime;
	}
}