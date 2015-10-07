using UnityEngine;
using System.Collections;

public class Test1 : MonoBehaviour {
	public bool test;
	public Test2 test2;
	public Test3 test3;

	[System.Serializable]
	public class Test2 {
		public int testInt;
	}

	[System.Serializable]
	public class Test3{
		public int namea;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
