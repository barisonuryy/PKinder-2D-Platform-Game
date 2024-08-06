using UnityEngine;
using System.Collections;

public class EnemyBugs : MonoBehaviour {
	
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
		
		//if 1 go down
		if (direction == 1)
			transform.Translate(Vector3.up * 1f * Time.deltaTime);
		
		//if 2 go left
		if (direction == 2)
			transform.Rotate(Vector3.back * 50f * Time.deltaTime);
		
	}
}
