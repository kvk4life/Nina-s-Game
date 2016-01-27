using UnityEngine;
using System.Collections;

public class Play_Animation : MonoBehaviour 
{
	public GameObject animHolder;	
	private Animator anim;
	
	void Start(){
		anim = animHolder.GetComponent<Animator> ();
	}

	public void Move(float moveSpeed)
	{
		//1 = walk, 2 = running
		anim.SetFloat("moveSpeed", moveSpeed);
	}
	
	public void Death()
	{
		anim.SetBool("death", true);
	}
	
	public void PickUp()
	{
		anim.SetTrigger("pickUp");
	}
	
	public void Gaurd(bool block)
	{
		anim.SetBool("guard", block);
	}
	
	public void Attack(float attack)
	{
		//0 = first attack, 1 = second attack, 2 is third attack
		anim.SetFloat("moveSpeed", attack);
	}
}
