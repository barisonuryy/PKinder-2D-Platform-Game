using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider other) 
	{
		if(other.tag == "joint")
		{
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().isKinematic = false;
		}
	}
}