using UnityEngine;
using System.Collections;

public class LeafMove : MonoBehaviour 
{
	public int moveSpeed;
	public GameObject leaf;
	public bool move;
	public int check;
	public float rotation;
	public Quaternion currentRotation;
	public Vector3 currentPosition;
	public GameObject player;
	public Vector3 currentPlayerPosision;
	public float timer;
	public float secondTimer;
	public float cooldown;

	void Start()
	{
		rotation = leaf.transform.rotation.y;
		currentPosition = leaf.transform.position;
		timer = 0;
	}

	void Update () 
	{
		//currentRotation = transform.rotation;

		if(move)
		{
			Mover();
		}
		else
		{
			leaf.transform.position = currentPosition;
		}

		if(timer >= 0)
		{
			timer -= Time.deltaTime;
		}

		if(secondTimer >= 0)
		{
			secondTimer -= Time.deltaTime;
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.transform.tag == "Player")
		{
			if(timer <= 0)
			{
				timer = cooldown;
				move = true;
				currentPlayerPosision = player.transform.position;
			}
		}

//		if(other.transform.tag == "Platform")
//		{
//			currentPosition = leaf.transform.position;
//
//			if(secondTimer <= 0)
//			{
//				if(check == 0)
//				{
//					check++;
//					secondTimer = 2;
//				}
//				else
//				{
//					//currentRotation.y = rotation;
//					//leaf.transform.rotation = currentRotation;
//					check--;
//
//					secondTimer = 2;
//				}
//			}
//				move = false;
//		}
	}

	void Mover()
	{
		//leaf.transform.Translate (0, 0, moveSpeed * Time.deltaTime);
		if(check == 1)
		{
			leaf.transform.position += this.moveSpeed * -transform.right * (float)Time.deltaTime;

			player.transform.position = currentPlayerPosision;
			
			player.transform.position += this.moveSpeed * -transform.right * (float)Time.deltaTime;
			
			currentPlayerPosision = player.transform.position;


			//transform.rotation = Quaternion.Euler (0,-180,0);
			//currentRotation.y += 180;//currentRotation.y;
			//leaf.transform.rotation = (Quaternion)currentRotation;
		}
		else
		{
			leaf.transform.position += this.moveSpeed * transform.right * (float)Time.deltaTime;

			player.transform.position = currentPlayerPosision;
			
			player.transform.position += this.moveSpeed * transform.right * (float)Time.deltaTime;
			
			currentPlayerPosision = player.transform.position;
		}
	}
}
