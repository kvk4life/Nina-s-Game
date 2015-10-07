using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {
	public float lowDamage;
	public float midDamage;
	public float highDamage;
	public float lowRange;
	public float midRange;
	public float highRange;
	public float fallVelocity;
	public Rigidbody rb;

	public void Start() {
		rb = GetComponent<Rigidbody>();
		Omzetter();
	}

	public void Update() {
		FallCheck();
	}

	public void FallCheck() {
		fallVelocity = rb.velocity.y;
	}

	public void Omzetter() {
		lowRange = lowRange - (lowRange * 2);
		midRange = midRange - (midRange * 2);
		highRange = highRange - (highRange * 2);
	}

	public void OnCollisionEnter(Collision col) {
		if (col.transform.tag == "Grond") {
			FallingDamage();
		}
	}

	public void FallingDamage() {
		if (fallVelocity < lowRange && fallVelocity > midRange) {
			GetComponent<PlayerHealth>().Damage(lowDamage);
		}
		else if (fallVelocity < midRange && fallVelocity > highRange) {
			GetComponent<PlayerHealth>().Damage(midDamage);
		}
		else if (fallVelocity < highRange) {
			GetComponent<PlayerHealth>().Damage(highDamage);
		}
	}
}
