using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	//public GameObject[] wayPoints;
	public Transform playerTarget;
	public Transform[]  waypointTarget;
	public int moveSpeed;
	//public Rigidbody rb;
	public AIStates aiStates;
	public int counter;
	public int wayLenght;
	public int patrolSpeed;
	public int chaseSpeed;
	public float moveTime;
	public float stopTime;
	public bool timeBool;
	public float randomNum;
	public int bonusSpeed;
	public Transform[] wayPointList;
	public float wayPointDistanceCheck;
	public int wayCounter;


	public enum AIStates{
		Patrol,
		Follow,
		Attacking
	}
	
	void Start () {
		waypointTarget = new Transform[wayLenght];

		wayCounter = 0;

		wayPointLister();

		aiStates = AIStates.Patrol;

	}

	void Update () {
		Vector3 positionWay = (waypointTarget[counter].position + new Vector3 (0, 0, 0)) - transform.position;

		Quaternion rotationWay = Quaternion.LookRotation(positionWay);

		Quaternion current = transform.localRotation;

		Timer ();

		if (aiStates == AIStates.Patrol) {

			DistanceCheck();
			Mover();

			transform.localRotation = Quaternion.Slerp(current, rotationWay, Time.deltaTime);

			moveSpeed+= bonusSpeed;
			bonusSpeed+= 1;

			if(moveTime > 0){
				timeBool = false;
				moveTime -= 1 * Time.deltaTime;
				moveSpeed = patrolSpeed;
			}
			if(stopTime > 0){	
				timeBool = true;
				stopTime -= 1 * Time.deltaTime;
				moveSpeed = 0;
				transform.Rotate (0, randomNum , 0);
			}
		}

		if (aiStates == AIStates.Follow){
			transform.LookAt(playerTarget);
			DistanceCheck();
			Mover();
			moveSpeed = chaseSpeed;
		}
		if (aiStates == AIStates.Attacking){
			DistanceCheck();
			moveSpeed = 0;
		}
	}

	void DistanceCheck() {
		float playerDist = Vector3.Distance(playerTarget.position, transform.position);
		float waypointDist = Vector3.Distance(waypointTarget[counter].position, transform.position);
		if( playerDist < 5){
			aiStates = AIStates.Follow;
			moveTime = 10;
			if(playerDist < 2){
				aiStates = AIStates.Attacking;
			}
		}

		else{
			if(waypointDist < 5){
				if(counter < wayLenght-1){
					RandomCounter();
					stopTime = 3;
					counter++;
				}
				else{
					RandomCounter();
					stopTime = 3;
					counter = 0;
				}
			}
		}

		if(playerDist > 10){
			bonusSpeed = 0;
			aiStates = AIStates.Patrol;
		}
	}

	void RandomCounter(){
		counter = (Random.Range(0, wayLenght-1));
	}

	void Timer (){
		if(timeBool == false){
			if(moveTime <= 0){
				randomNum = (Random.Range(-1.5F, 1.5F));
				stopTime = 3;
				timeBool = true;
			}
		}
		if(timeBool){
			if(stopTime <= 0){
				moveTime = 6;
				timeBool = false;
			}
		}
	}

	void wayPointLister(){
		for(int i = 0; i < wayPointList.Length; i++) {
			float wayCheckDistance = Vector3.Distance(wayPointList[i].position, transform.position);
			if( wayCheckDistance < wayPointDistanceCheck ){
				waypointTarget[wayCounter] = wayPointList[i];
				if(wayCounter < waypointTarget.Length)	{
					wayCounter++;
				}
				else{
					wayCounter = 0;
				}
			}
		}
	}

	void Mover(){
		transform.Translate (0, 0, moveSpeed * Time.deltaTime);
	}
}
