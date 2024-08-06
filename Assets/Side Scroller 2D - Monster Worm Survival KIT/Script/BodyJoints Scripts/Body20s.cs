using UnityEngine;
using System.Collections;

public class Body20s : MonoBehaviour {

		void Start() {
			StartCoroutine(Example());
		}
		
		IEnumerator Example() {
			print(Time.time);
			yield return new WaitForSeconds(20);
			print(Time.time);
			GetComponent<Renderer>().enabled = true;
		}
		
	}