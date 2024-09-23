using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGAreaButtonMec : MonoBehaviour
{
    private bool isCame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            isCame = true;
        }
    }
}
