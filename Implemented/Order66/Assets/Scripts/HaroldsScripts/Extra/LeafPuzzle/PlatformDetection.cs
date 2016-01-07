using UnityEngine;
using System.Collections;

public class PlatformDetection : MonoBehaviour {
	LeafMove leafMove;
	public GameObject leafMoveHolder;

	void Start(){
		leafMove = leafMoveHolder.GetComponent<LeafMove> ();
	}

	void OnCollisionEnter(Collision other) 
	{		
		if(other.transform.tag == "Platform")
		{
			leafMove.currentPosition = leafMove.leaf.transform.position;

			if(leafMove.secondTimer <= 0)
			{
				if(leafMove.check == 0)
				{
					leafMove.check++;
					leafMove.secondTimer = 2;
				}
				else
				{
					//currentRotation.y = rotation;
					//leaf.transform.rotation = currentRotation;
					leafMove.check--;

					leafMove.secondTimer = 2;
				}
			}
			leafMove.move = false;
		}
	}
}
