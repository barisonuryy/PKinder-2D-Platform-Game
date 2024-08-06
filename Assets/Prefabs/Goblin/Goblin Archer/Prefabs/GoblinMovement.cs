using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float Range;

    private Animator anim;
    // Start is called before the first frame update
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Math.Abs(player.position.x - gameObject.transform.position.x) > Range)
        {

            Vector2 targetPoint= Vector2.MoveTowards(gameObject.transform.position,
                new Vector2(player.position.x, gameObject.transform.position.y), Time.deltaTime);
            if (targetPoint.x != 0)
            {
                anim.SetBool("walk",true);
            }
            else
            {
                anim.SetBool("walk",false);
            }
            gameObject.transform.position = targetPoint;
        }
        else
        {
            anim.SetBool("walk",false);
        }

        if (player.position.x - gameObject.transform.position.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 1);  // Sola bak
        }
        else if (player.position.x - gameObject.transform.position.x > 0)
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);   // Sağa bak
        }
        
    }
}
