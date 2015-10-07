﻿using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	public Transform target;

	void Update () {
		Vector3 relativePos = target.position - transform.position;
		transform.rotation = Quaternion.LookRotation(relativePos);
	}
}
//Vector3 relativePos = target.position - transform.position;
//Quaternion rotation = Quaternion.LookRotation(relativePos);
//
//Quaternion current = transform.localRotation;
//
//transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
//transform.Translate (0,0,3 * Time.deltaTime);