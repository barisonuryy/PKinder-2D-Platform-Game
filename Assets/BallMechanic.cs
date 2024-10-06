using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] private GameObject rbCharacter;


    [SerializeField] private GameObject _lineRenderer,_lineRenderer1;
    private float sizeX, sizeY;
    [SerializeField] private float triggerSizeX, triggerSizeY,speedXY,speedScaler;
    private bool isComplete,isIn;
    public LayerMask layerMaskToCheck;
    private Vector3 distance,tempDistance;
    private float gravityVal;
    private bool isTouch;
    private bool isActive;
    private Rigidbody2D rb;
    

    public bool playerIsIn;
    // Start is called before the first frame update
    void Start()
    {
   
        gravityVal = rbCharacter.GetComponent<Rigidbody2D>().gravityScale;
        rb = GetComponent<Rigidbody2D>();
        isComplete = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            
            isIn = Physics2D.OverlapCircle(gameObject.transform.position - new Vector3(0.05f, 0, 0), 2F, layerMaskToCheck);
        
            if (isIn)
            {
                Time.timeScale = 0.6f;
                _lineRenderer.SetActive(true);
                
                //_lineRenderer1.SetActive(true);



            }
            else
            {
                Time.timeScale=Mathf.Lerp(Time.timeScale, 1, Time.deltaTime/2);
                if (Time.timeScale > 0.999f)
                {
                    Time.timeScale = 1F;
                }
                Debug.Log("TimeScaleee"+Time.timeScale);
                _lineRenderer.SetActive(false);
                //_lineRenderer1.SetActive(false);
            }

            if (Input.GetMouseButtonUp(1)&&isIn)
            {
            
                distance = -(_lineRenderer.GetComponent<LineRenderer>().GetPosition(1)-_lineRenderer.GetComponent<LineRenderer>().GetPosition(0));
                tempDistance = distance;
                Debug.Log("Distance: " + distance);
                rbCharacter.GetComponent<Rigidbody2D>().velocity = distance * speedXY;
                Invoke(nameof(ThrowCharacter),0.05f);
            
            }

        }
        else
        {
            Time.timeScale=Mathf.Lerp(Time.timeScale, 1, Time.deltaTime);
            
        }
      
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position,new Vector3(triggerSizeX,triggerSizeY,1));
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position+new Vector3(0.05f,0,0),2f);
    }

    void ThrowCharacter()
    {
       // rbCharacter.GetComponent<Rigidbody2D>().gravityScale = 0f;
        rbCharacter.GetComponent<SpriteRenderer>().enabled = true;
        rbCharacter.GetComponent<BasicMech>().canUseMovement = false;
        rbCharacter.GetComponent<Rigidbody2D>().AddForce( distance * speedScaler,ForceMode2D.Impulse); 
        rb.velocity = -tempDistance * 4f;
        Invoke(nameof(ResetGravity),0.25f);
        
    }

    void ResetGravity()
    {
        rbCharacter.GetComponent<BasicMech>().canUseMovement = true;
        rbCharacter.GetComponent<Rigidbody2D>().gravityScale = gravityVal;
    }

   

}
