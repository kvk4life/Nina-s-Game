using UnityEngine;
using System.Collections;

public class CheatScript : MonoBehaviour 
{
	public bool cheatMode;
	public float normalMoveSpeed;
	public float cheatSpeed;
	public int cheatJump;
	public int normalJumpHeight;

	void Start () 
	{
		cheatMode = false;
	}

	void Update () 
	{
		if(cheatMode == false)
		{
			if(Input.GetButton("8"))
			{
				if(Input.GetButton("9"))
				{
					if(Input.GetButton("0"))
					{
						Movement movementScript = GetComponent<Movement> ();
						normalMoveSpeed = movementScript.moveSpeed;
						normalJumpHeight = movementScript.jumpHeight;
						cheatMode = true;
					}
				}
			}
		}
		else
		{
			if(Input.GetButton("0"))
			{
				if(Input.GetButton("9"))
				{
					if(Input.GetButton("8"))
					{
						Movement movementScript = GetComponent<Movement> ();
						movementScript.moveSpeed = normalMoveSpeed;
						movementScript.jumpHeight = normalJumpHeight;
						cheatMode = false;
					}
				}
			}
		}
		if(cheatMode)
		{
			Movement movementScript = GetComponent<Movement> ();
			movementScript.moveSpeed = cheatSpeed;
			movementScript.jumpHeight = cheatJump;
			movementScript.jumpCounter = 0;
		}
	}
}
