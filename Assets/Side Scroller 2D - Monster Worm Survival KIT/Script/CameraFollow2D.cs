using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {
		
		private Vector3 velocity = Vector3.zero;
		public Transform target;

		void Update () 
			{
			if (target)
			{
				Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
				//Settings for the camera view.
				Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.4f, point.z));
				Vector3 destination = transform.position + delta;
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0);
			}
		}
	}
