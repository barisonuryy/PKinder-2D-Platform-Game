using UnityEngine;
using System.Collections;

public class Body40s : MonoBehaviour {

	void Start() {
		StartCoroutine(Example());
	}
	
	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(40);
		print(Time.time);
		GetComponent<Renderer>().enabled = true;
	}
	
}