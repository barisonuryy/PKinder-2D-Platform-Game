using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamScript : MonoBehaviour {

	public AudioClip audio01;
	void  Update (){
		if (Input.GetKeyDown ("b"))
		{
			GetComponent<AudioSource>().PlayOneShot(audio01);
			//GetComponent<AudioSource>().PlayOneShot(ScoreSound, 7.7F);
		}
	}
}