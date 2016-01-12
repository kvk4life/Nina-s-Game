using UnityEngine;
using System.Collections;

public class LeafPuzzleFix : MonoBehaviour 
{
	public float timer;
	public float cooldown;
	public GameObject temp;

	void Update () 
	{
		if(timer >= 0)
		{
			timer-= Time.deltaTime;
		}
		else
		{
			if(temp != null)
			{
				temp.GetComponent<BoxCollider>().enabled = true;
				temp = null;
			}
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		if(other.transform.tag == "CobWeb")
		{
			other.GetComponent<BoxCollider>().enabled = false;
			temp = other.gameObject;
			timer = cooldown;
		}
	}
}