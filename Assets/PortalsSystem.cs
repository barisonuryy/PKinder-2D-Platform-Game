using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PortalsSystem : MonoBehaviour
{
    [SerializeField] private GameObject rbCharacter;

    private BoxCollider2D _boxCollider2D;
    public GameObject portalA, portalB;
    [SerializeField] private float durationF,durationS,finalEdgeF,startEdgeF,finalEdgeS,startEdgeS,startEdgeX,finalEdgeX;
    [SerializeField] private GameObject _lineRenderer,_lineRenderer1;
    private float sizeX, sizeY;
    [SerializeField] private float triggerSizeX, triggerSizeY,speedXY;
    private bool isComplete,isIn;
    public LayerMask layerMaskToCheck;
    private Vector3 distance,tempDistance;
    private float gravityVal;
    private bool isTouch;

    private bool isClicked;

    public bool playerIsIn;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = true;
        gravityVal = rbCharacter.GetComponent<Rigidbody2D>().gravityScale;
        isComplete = true;
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        sizeX = _boxCollider2D.size.x;
        sizeY = _boxCollider2D.size.y;
        Debug.Log("Collider Büyüklüğü"+sizeX+""+sizeY);
    }

    private void FixedUpdate()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(isComplete)
        StartCoroutine(producePortal());
        isTouch=Physics2D.OverlapBox(portalA.transform.position, new Vector3(triggerSizeX, triggerSizeY, 1),
            portalA.transform.rotation.z,layerMaskToCheck);
        isIn = Physics2D.OverlapCircle(portalA.transform.position - new Vector3(0.1f, 0, 0), 1.5F, layerMaskToCheck);
        
        if (isTouch&&isClicked)
        {
            _lineRenderer.SetActive(true); 
            _lineRenderer1.SetActive(true);
   
            
           
        }
        else
        {
            
            _lineRenderer.SetActive(false);
            _lineRenderer1.SetActive(false);
        }

        if (Input.GetMouseButtonUp(1)&&isClicked&&isIn)
        {
            isClicked = false;
            distance = -(_lineRenderer.GetComponent<LineRenderer>().GetPosition(1)-_lineRenderer.GetComponent<LineRenderer>().GetPosition(0));
            tempDistance = distance;
          
            rbCharacter.GetComponent<Rigidbody2D>().velocity = distance * speedXY;
            portalA.SetActive(false);
          
            if (isIn)
            {
               
                rbCharacter.GetComponent<SpriteRenderer>().enabled = false;
                rbCharacter.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
                Invoke(nameof(ThrowCharacter),0.05f);
            }
         
        
        }

       
            _lineRenderer1.GetComponent<LineRenderer>().SetPosition(0,portalB.transform.position);
            _lineRenderer1.GetComponent<LineRenderer>().SetPosition(1,portalB.transform.position+tempDistance);
    
      


      
        
        
        
        
    }

    

    IEnumerator producePortal()
    {
        isComplete = false;
        isClicked = true;
        float randomRotF = Random.Range(0, 180);
        float randomRotS = Random.Range(0, 180);
        float randomFX = Random.Range(startEdgeX, finalEdgeX);
        float randomFY = Random.Range(startEdgeF, finalEdgeF);
        float randomSX = Random.Range(startEdgeX, finalEdgeX);
        float randomSY = Random.Range(startEdgeS , finalEdgeS);
       portalA.SetActive(true);
       portalB.SetActive(true);
       
       portalA.transform.SetLocalPositionAndRotation(new Vector3(randomFX,randomFY,0),Quaternion.Euler(portalA.transform.eulerAngles.x,portalA.transform.eulerAngles.y,randomRotF));
       portalB.transform.SetLocalPositionAndRotation(new Vector3(randomSX,randomSY,0),Quaternion.Euler(portalB.transform.eulerAngles.x,portalB.transform.eulerAngles.y,randomRotS));
       yield return new WaitForSeconds(durationF);
       _lineRenderer1.SetActive(false);
       _lineRenderer.SetActive(false);
       portalA.SetActive(false);
       portalB.SetActive(false);
       yield return new WaitForSeconds(3f);
       tempDistance = Vector3.zero;
       isComplete = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(portalA.transform.position,new Vector3(triggerSizeX,triggerSizeY,1));
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(portalA.transform.position-new Vector3(0.1f,0,0),1.5f);
    }

    void ThrowCharacter()
    {
        Debug.Log("Krakter fırlatıldı");
        rbCharacter.transform.position = portalB.transform.position;
        rbCharacter.GetComponent<Rigidbody2D>().gravityScale = 0f;
        rbCharacter.GetComponent<SpriteRenderer>().enabled = true;
        rbCharacter.GetComponent<BasicMech>().enabled = false;
        rbCharacter.GetComponent<Rigidbody2D>().velocity = tempDistance * 2f;
        Invoke(nameof(ResetGravity),0.25f);
        
    }

    void ResetGravity()
    {
        rbCharacter.GetComponent<BasicMech>().enabled = true;
        rbCharacter.GetComponent<Rigidbody2D>().gravityScale = gravityVal;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsIn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsIn = true;
        }
    }
}
