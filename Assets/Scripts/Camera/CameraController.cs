using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public float followSpeed=0.125f;
  

    private void Start()
    {
    
    }

    void LateUpdate()
    {
      if(target != null)
        transform.position=Vector3.Lerp(target.position,target.position+offset,followSpeed);
    }
    
}
