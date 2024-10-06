using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class rotatorMech : MonoBehaviour
{
    private bool isInArea,isApplied;
    public bool canMove;
    private int count;
    private bool canUse;
    [SerializeField] float sizeVal,xVal,sizeVal1,xVal1,sizeVal2,xVal2;
    [SerializeField] private GameObject player,camera;
    float defaultValCam, defaultValCam2;

    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        defaultValCam = camera.GetComponent<Camera>().orthographicSize;
        defaultValCam2 = camera.GetComponent<CameraController>().offset.x;
        canMove = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
     if(canUse)
         setMovement();
      
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyUp(KeyCode.E)&&!isApplied)
            {
                canMove = !canMove;
                isApplied = true;
                if(canMove)
                    TurnOffPlayerMovement();
                else
                    TurnOnPlayerMovement();
                
                
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = false;
            player.GetComponent<BasicMech>().canInteract = false;
            isApplied = false;

        }
    }


    void TurnOnPlayerMovement()
    {
        player.GetComponent<BasicMech>().canInteract = false;
        isApplied = false;
        canUse = false;
        camera.GetComponent<CameraController>().offset.x = defaultValCam2;
        camera.GetComponent<Camera>().orthographicSize = defaultValCam;
    }
    void TurnOffPlayerMovement()
    {
        player.GetComponent<BasicMech>().canInteract = true;
        isApplied = false;
        canUse = true;
        if (gameObject.name == "RotatorManuel")
        {
            camera.GetComponent<CameraController>().offset.x = 0;
            camera.GetComponent<Camera>().orthographicSize = sizeVal;
        }
        else if(gameObject.name == "RotatorManuel (1)")
        {
            camera.GetComponent<CameraController>().offset.x = xVal1;
            camera.GetComponent<Camera>().orthographicSize = sizeVal1;
        }
        else if(gameObject.name == "RotatorManuel (2)")
        {
            camera.GetComponent<CameraController>().offset = new Vector3(xVal2,-xVal2,-20);
            camera.GetComponent<Camera>().orthographicSize = sizeVal2;
        }

        
    }

    void setMovement()
    {
        
        float val = Input.GetAxisRaw("Horizontal");
        gameObject.transform.Rotate(Vector3.forward*rotateSpeed*val*Time.deltaTime);
    }
    
}
