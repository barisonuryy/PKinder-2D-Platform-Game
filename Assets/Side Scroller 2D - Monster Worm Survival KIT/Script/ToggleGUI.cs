using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGUI : MonoBehaviour {

	private bool visible = false;

	private bool windowRect = false;
	public Texture PauseTexture;

	void  Start (){
		///visible = false;
		//windowRect = new Rect( 510,510, 500,500);
	}

	void  OnTriggerEnter ( Collider other  ){
		OnGUI();

	}
	void  OnGUI (){

		if( visible )
		{
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), PauseTexture);
		}

	}
	void  Update (){
		if( Input.GetKeyDown( KeyCode.P ) )
		{
			visible = !visible;

		}
	}

}