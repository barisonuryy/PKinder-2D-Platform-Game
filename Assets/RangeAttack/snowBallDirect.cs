using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBallDirect : MonoBehaviour
{

    
    // Start is called before the first frame update
   Rigidbody2D rb;
    bool hasHit;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


          float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
          transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
          
        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
   

        if (collision.collider.CompareTag("Archer"))
        {
            Debug.Log("Değdiiiiiii1");
            collision.collider.GetComponent<GoblinHealth>().TakeDamageGoblin(5);
          

        }

        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Değdiiiiiii2");
            collision.collider.GetComponent<MinotaurHealth>().TakeDamageMinotaur(5);
            
        }
        if (collision.collider.gameObject.CompareTag("Witcher"))
        {
            Debug.Log("Değdiiiiiii3");
            collision.collider.GetComponentInParent<WitcherHealth>().TakeDamageWitcher(5);
            ;
        }

        if (collision.collider.gameObject.CompareTag("LaserEnemy"))
        {
            Debug.Log("Değdiiiiiii2");
            Destroy(collision.collider.gameObject);

        }
        
        Destroy(gameObject);



    }
}
