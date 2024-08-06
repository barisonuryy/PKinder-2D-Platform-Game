using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour {
	private float fTurnRate = 90.0f;  // 90 degrees of turning per second
	private float fSpeed = 0.0f;  // Units per second of movement;
	
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate (Vector3.forward * fTurnRate * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow))
			transform.Rotate (-Vector3.forward * fTurnRate * Time.deltaTime);
		transform.localPosition = transform.localPosition + transform.up * fSpeed * Time.deltaTime;
	}
}