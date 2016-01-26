using UnityEngine;
using System.Collections;

public class Play_Animation : MonoBehaviour 
{
	public Animator anim;	


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

	public void Gaurd()
	{
		anim.SetBool("guard", true);
	}

	public void StopGuard()
	{
		anim.SetBool("guard", false);
	}

	public void Attack(float attack)
	{
		//0 = first attack, 1 = second attack, 2 is third attack
		anim.SetFloat("moveSpeed", attack);
	}
}
