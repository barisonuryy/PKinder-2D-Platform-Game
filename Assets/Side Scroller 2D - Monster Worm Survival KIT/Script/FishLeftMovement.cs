﻿using UnityEngine;
using System.Collections;

public class FishLeftMovement : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		StartCoroutine("changeDirection");
		
	}
	
	int direction = 0;
	
	
	IEnumerator changeDirection()
	{
		while (true)
		{
			
			
			direction = Random.Range(0, 5);
			
			
			
			yield return new WaitForSeconds(1f);
		}
		
		
		
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		//if 3 go right
		if (direction == 3)
			transform.Translate(Vector3.right * 1f * Time.deltaTime);
	}
}