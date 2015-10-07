using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemie_Insantiater : CurLevel{
	public GameObject[] spawnPoints;
	public GameObject[] enemyPrefab;
	List<GameObject> enemies = new List<GameObject>();	

	public int enemyInsertingInt;
	public static int enemyCount = 0;
	int enemyNumber;

	new void OnTriggerEnter(){
		EnemyInstanter ();
	}

	void EnemyInstanter(){
		for(int spCount = 0; spCount < enemyInsertingInt; spCount++){
			int curSpawn = Random.Range (0, spawnPoints.Length);
			int curEnemy = curLevel;
			Vector3 spawnPos = new Vector3();
			Quaternion spawnRot = new Quaternion();
			spawnPos = spawnPoints[curSpawn].transform.position;
			spawnRot = spawnPoints[curSpawn].transform.rotation;
			GameObject enemy = Instantiate (enemyPrefab[curEnemy], spawnPos, spawnRot) as GameObject;
			enemies.Add(enemy);
			enemy.name = "enemy" + enemyNumber;
			enemy.GetComponent<Enemy_Stats>().number = enemyNumber;
			enemyNumber++;
			enemyCount++;
		}
	}
}
