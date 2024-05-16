using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMech : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject trRotator;
    [SerializeField] private moveableButtonMech canTurn;
    [SerializeField] private float TurnSpeed;
    [SerializeField] private float resetTime;
    public float maxRotationAngle = 90f;
    private float totalTime;
    private bool isControllable;
    private bool isReverse;
    public bool isInEnergyArea;

    void Start()
    {
        if (gameObject.name == "ControllableLaser")
        {
            isControllable = true;
        }
        else if (gameObject.name == "ReverseLaser")
        {
            isReverse = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isControllable)
        {
            if (canTurn != null)
            {
                if (canTurn.isTurned)
                {
         

                    bool isRelate = trRotator.GetComponent<rotatorMech>().canMove;
                    float turnVal = Input.GetAxis("Horizontal");
                    if(totalTime<resetTime&&isRelate)
                        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,trRotator.transform.rotation.eulerAngles.z-90);
                    else
                    {
                        if ((transform.eulerAngles.z >= 270 && transform.eulerAngles.z <= 360) ||
                            (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 90))
                        {
                            transform.Rotate(TurnSpeed*Vector3.back*Time.deltaTime);
                        }
                    }
                    if (turnVal == 0)
                    {
                        totalTime += Time.deltaTime;
                    }
                    else
                    {
                        totalTime = 0;
                    }
                }
            }
           
        }
        else
        {
            bool isRelate = trRotator.GetComponent<rotatorMech>().canMove;
            if(isRelate)
                gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,trRotator.transform.rotation.eulerAngles.z-90);
      
        }
       

        


        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "EnergyTriangle")
        {
            Debug.Log("Alana girildi");
            isInEnergyArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "EnergyTriangle")
        {
            isInEnergyArea = false;
        }
    }
}