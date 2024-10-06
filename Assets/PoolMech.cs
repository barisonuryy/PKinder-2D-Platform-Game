using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMech : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isInWater;
    private BasicMech _basicMech;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        _basicMech = GetComponent<BasicMech>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isInWater)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            // Karakterin hareket ettiği yöne doğru rotasyon yap
            if (movement != Vector2.zero)
            {
                float angle = Mathf.Atan2(-movement.x, movement.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
       
    }

    void FixedUpdate()
    {
       if(isInWater)
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pool"))
        {
            isInWater = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pool"))
        {
           anim.SetBool("isSwim",true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pool"))
        {
            anim.SetBool("isSwim", false);
            isInWater = false;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
