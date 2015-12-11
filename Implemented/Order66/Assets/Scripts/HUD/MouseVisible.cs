using UnityEngine;
using System.Collections;

public class MouseVisible : MonoBehaviour {

	public void Start(){
		CursorVisibility (false);
	}
	
	public void CursorVisibility(bool visibly){
		Cursor.visible = visibly;
	}
}
