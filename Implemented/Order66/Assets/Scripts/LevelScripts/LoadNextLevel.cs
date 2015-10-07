using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {
	public string nextLevel;

	public void GoToNextLevel () {
		Application.LoadLevel(nextLevel);
	}
}
