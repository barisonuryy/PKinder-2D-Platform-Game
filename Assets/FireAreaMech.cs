using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAreaMech : MonoBehaviour
{
    
    public GameObject[] objects;  // Objeleri bu diziye atayın
    public Transform player;

    private bool canStart;// Oyuncunun pozisyonunu referans alın
     // Objelerin düşme hızı

    private GameObject closestObject;

    void Update()
    {
        if (canStart)
        {
            float closestDistance = Mathf.Infinity;

            // Tüm objeler için mesafe kontrolü yapıyoruz
            foreach (GameObject obj in objects)
            {
                float distance = Mathf.Abs(obj.transform.position.x - player.position.x);
            
                // En yakın objeyi buluyoruz
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }

            // En yakın objeyi düşürüyoruz
            if (closestObject != null)
            {
                closestObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                closestObject.transform.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canStart = true;
        }
    }
}
