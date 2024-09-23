using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7LButton : MonoBehaviour
{
    private LevelLoadManager _levelLoadManager;
    [SerializeField] LightManager _lightManager;
    private bool isPressed;

    private void Start()
    {
        isPressed = true;
    }

    private void Update()
    {
       
    }

 

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (Input.GetKey(KeyCode.E)&&_lightManager!=null&&isPressed)
            {
                _lightManager.openLight();
                isPressed = false;
            }
        }
    }
}
