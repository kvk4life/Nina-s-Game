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
	public float groundRayDis;
	public bool mayJump;
	public RaycastHit rayHit;
	public GameObject walkParticle;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		Rotation();
		//JumpCounterCheckerHarold ();
		MayMoveChecker ();
//		if (Physics.Raycast(transform.position, -Vector3.up + new Vector3(0, groundRayDis, 0),out rayHit, jumpCheck)){
//			jumpCounter = 0;
//			GetComponent<PlayerLeafActivate>().ActiveLeave(rayHit);
//		}
		if (mayMove) {
			Moving ();
		}
		if (Input.GetButtonDown ("Jump")) {
			Jump();
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.transform.tag == "Platform") {
			jumpCounter = 0;
		} 
	}

	void JumpCounterCheckerHarold(){
		if (Physics.Raycast(transform.position, -Vector3.up + new Vector3(0, groundRayDis, 0),out rayHit, jumpCheck)){
			jumpCounter = 0;
			GetComponent<PlayerLeafActivate>().ActiveLeave(rayHit);
		}
		else{
			jumpCounter = 1;
		}
		if (Input.GetButtonDown ("Jump")) {
			Jump();
		}
	}

	void MayMoveChecker(){
		if (Physics.Raycast (transform.position, transform.forward, wallRayDis)){
			if(mayMove)	{
				mayMove = false;
			}
		}
		else{
			mayMove = true;
		}
	}

	void FixedUpdate(){
		CameraControler ();
	}

	void CameraControler(){
		if(Input.GetButton("Horizontal"))
		{
		}
		else
		{
			if(Input.GetMouseButton(0) || Input.GetButton("Vertical")) 
			{
				transform.rotation = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0);
			} 
		}
	}

	void Moving() {
		float translation = Input.GetAxis("Vertical") * moveSpeed;
		translation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
	}

	void Jump (){
		if(mayJump){
			if (jumpCounter < 1) {
				rb.velocity = new Vector3 (0, jumpHeight, 0);
				jumpCounter = 1;
			}
		}
	}

	void Rotation() {
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		transform.Rotate(0, rotation, 0);
		rotation *= Time.deltaTime;
	}
}