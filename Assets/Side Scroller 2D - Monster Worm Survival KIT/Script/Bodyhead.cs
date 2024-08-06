using UnityEngine;
using System.Collections;

public class Bodyhead : MonoBehaviour {
	public GameObject goLeader = null;
	
	void Update () {
		if (goLeader == null) return;
		Vector3 v3FromLeader =  transform.position - goLeader.transform.position;
		v3FromLeader = v3FromLeader.normalized * transform.localScale.y;  
		transform.position = v3FromLeader + goLeader.transform.position;
	}
}