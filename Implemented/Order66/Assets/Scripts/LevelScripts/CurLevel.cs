using UnityEngine;
using System.Collections;

public class CurLevel : LevelStats {
	int myLevel = 0;
	public static int curLevel;

	public void OnTriggerEnter(){
		myLevel = levelNum;
		LevelSwitch (myLevel);
	}

	public int LevelSwitch(int thisLevel){
		curLevel = thisLevel;
		return curLevel;
	}
}
