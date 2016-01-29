﻿using UnityEngine;
using System.Collections;

public class BreathHolding : MonoBehaviour {
	public float curBreath;
	public float maxBreath;
	public float breathRegen;
	public float breathReduce;
	public float regenRate;
	public float reduceRate;
	public float noBreathDamage;
	public float noBreathDamageRate;
	float nextReduce;
	float nextRegen;
	float minBreath;

	public bool holdBreath;
	public bool inSafeZone;

	public void Start(){
		curBreath = maxBreath;
		minBreath = 0;
	}

	public void Update(){
		Equalizer ();
		HoldingBreath ();
		Reducer ();
		Regenerator ();
	}

	
	public void Equalizer(){
		if(curBreath > maxBreath){
			curBreath = maxBreath;
		}
		if(curBreath < minBreath){
			curBreath = minBreath;
		}
	}

	public void HoldingBreath(){
		if (Input.GetButton ("HoldBreath") && curBreath > minBreath) {
			holdBreath = true;
		}
		else{
			holdBreath = false;
		}
	}

	public void Reducer(){
		if (Time.time > reduceRate + nextReduce && holdBreath) {
			curBreath -= breathReduce;
			nextReduce = Time.time;
		}
		if (curBreath < minBreath + 1) {
			if(Time.time > noBreathDamageRate + nextReduce){
				GetComponent<PlayerHealth> ().Damage (noBreathDamage);
				nextReduce = Time.time;
			}
		}
	}

	public void Regenerator(){
		if(curBreath < maxBreath && !holdBreath){
			if(Time.time > regenRate + nextRegen){
				curBreath += breathRegen;
				nextRegen = Time.time;
			}
		}
	}
}
