using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicPortalMech : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject rbCharacter;

    private BoxCollider2D _boxCollider2D;
    public GameObject portalA, portalB;
  
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
