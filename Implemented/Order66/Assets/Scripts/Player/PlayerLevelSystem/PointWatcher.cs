using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointWatcher : MonoBehaviour {
	private GameObject player;
	public int skillPointsLeft;
	public int skillPointsSpend;
	public Text available;
	public Text spend;

	public void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void Update(){
		LinkPointsInPool ();
	}

	public void LinkPointsInPool(){
		skillPointsLeft = player.GetComponent<SkillTree> ().skillPointPool;
		skillPointsSpend = player.GetComponent<SkillTree> ().spendSkillPoints;
		available.text = skillPointsLeft.ToString();
		spend.text = skillPointsSpend.ToString ();
	}
}
