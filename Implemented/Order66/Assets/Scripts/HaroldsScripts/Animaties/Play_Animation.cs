using UnityEngine;
using System.Collections;

public class Play_Animation : MonoBehaviour 
{
	public Animator animation;	


	void Move(float moveSpeed)
	{
		//1 = walk, 2 = running
		animation.SetFloat("moveSpeed", moveSpeed);
	}

	public void Death()
	{
		animation.SetBool("death", true);
	}
		
	public void PickUp()
	{
		animation.SetTrigger("pickUp");
	}

	public void Gaurd()
	{
		animation.SetBool("guard", true);
	}

	public void StopGuard()
	{
		animation.SetBool("guard", false);
	}

	public void Attack(float attack)
	{
		//0 = first attack, 1 = second attack, 2 is third attack
		animation.SetFloat("moveSpeed", attack);
	}
}
