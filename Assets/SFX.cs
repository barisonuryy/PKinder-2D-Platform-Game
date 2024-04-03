using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource attack;
    public AudioSource slide;

   

    // Update is called once per frame
    void Update()
    {
      

       PlayAttackSFX();
       PlaySlideSFX();

    }
    private void PlayAttackSFX()
    {
        BasicMech canSound = GetComponent<BasicMech>();
        bool attackS = canSound.attack;
        if (attackS)
        {
            
            attack.Play();
        }
    }


    private void PlaySlideSFX()
    {
        BasicMech canSound = GetComponent<BasicMech>();
        bool slideS = canSound.isDashing;
        if (slideS)
        {
            slide.Play();
        }
    }

  
}
