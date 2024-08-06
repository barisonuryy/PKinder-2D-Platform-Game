using UnityEngine;
using System.Collections;

public class Body10s : MonoBehaviour {
	
		void Start() {
			StartCoroutine(Example());
		}
		
		IEnumerator Example() {
			print(Time.time);
			yield return new WaitForSeconds(10);
			print(Time.time);
			GetComponent<Renderer>().enabled = true;
		}
		
	}