using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButtonColliderControl : MonoBehaviour
{
    public bool canTurn;
        
    // Start is called before the first frame update
   

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            canTurn = !canTurn;
            
            
        }
    }
}
