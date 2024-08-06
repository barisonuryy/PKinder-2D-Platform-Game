using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFootsteps : MonoBehaviour {

	public AudioClip AudioFile;

	void  Start (){

	}

	void  Update (){

		if (Input.GetKeyDown (KeyCode.W))
		{
			GetComponent<AudioSource>().clip = AudioFile;
			GetComponent<AudioSource>().Play();

		}

		if (Input.GetKeyUp (KeyCode.W))
		{
			GetComponent<AudioSource>().clip = AudioFile;
			GetComponent<AudioSource>().Stop();

		}

	}
}