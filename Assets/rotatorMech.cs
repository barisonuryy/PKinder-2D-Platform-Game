using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatorMech : MonoBehaviour
{
    private bool isInArea,isApplied;
    public bool canMove;
    private int count;
    private bool canUse;
    [SerializeField] private GameObject player;

    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
           TurnOffPlayerMovement();
        }
        else
        {
            TurnOnPlayerMovement();
        } 
        Debug.Log("canMoveDeger"+canMove);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E)&&!isApplied)
            {
                canMove = !canMove;
                isApplied = true;
              
                
            }

        }
    }
    

    void TurnOnPlayerMovement()
    {
        player.GetComponent<BasicMech>().enabled = true;
        isApplied = false;
    }
    void TurnOffPlayerMovement()
    {
        player.GetComponent<BasicMech>().enabled = false;
        isApplied = false;
        setMovement();
    }

    void setMovement()
    {
        
        float val = Input.GetAxisRaw("Horizontal");
        gameObject.transform.Rotate(Vector3.forward*rotateSpeed*val*Time.deltaTime);
    }
    
}
