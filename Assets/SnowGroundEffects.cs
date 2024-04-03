using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGroundEffects : MonoBehaviour
{
    [SerializeField] private BasicMech isPressed;
    [SerializeField] private AudioSource[] sfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(("Player")) && Input.GetButton("Horizontal"))
        {
            if(!sfx[0].isPlaying)
            sfx[0].PlayDelayed(0.001f);
            else
            {
                return;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(("Player")) && !isPressed.jump)
        {
            sfx[1].Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(("Player")) && !isPressed.jump)
        {
            sfx[2].Play();
        }
    }
}
