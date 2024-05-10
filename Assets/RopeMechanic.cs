using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMechanic : MonoBehaviour
{
    [SerializeField] private float scaleSpeed;
    // Start is called before the first frame update
    
// Büyüme hızı

    void Update()
    {
        // X ekseni boyunca büyütme
        transform.localScale += new Vector3(scaleSpeed, 0, 0) * Time.deltaTime;
    }
}
