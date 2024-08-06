using UnityEngine;
using System.Collections;

public class Body30s : MonoBehaviour {

	void Start() {
		StartCoroutine(Example());
	}
	
	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(30);
		print(Time.time);
		GetComponent<Renderer>().enabled = true;
	}
	
}