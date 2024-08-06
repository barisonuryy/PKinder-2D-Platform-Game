using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrexAttack : MonoBehaviour
{
    Animator anim;
    private bool isJump,isPatrol;
    Rigidbody2D rb;
    [Header("Time")]
    [SerializeField] float jumpCoolDown;
    [Header("For Petrolling")]
    [SerializeField] float moveSpeed;
    public float moveDirection = -1;
    private bool facingRight = false;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] float circleRadius;
    private bool checkingGround;
    private bool checkingWall;


    [Header("For JumpAttacking")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform playerT;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded;
 
    [Header("ForSeeingPlayer")]
    [SerializeField] Vector2 lineofSite;
    [SerializeField] LayerMask player;
    private bool canSeePlayer;
    private float defaultCheckVal,defaultCheckVal2;
    [SerializeField] private GameObject groundGameObject,wallGameObject;
    [SerializeField] private float randomMax, randomMed,randomMin;

    private CapsuleCollider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        defaultCheckVal = groundGameObject.transform.localPosition.y;
        defaultCheckVal2 = wallGameObject.transform.localPosition.y;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.y > 2)
        {
            _collider2D.enabled = true;
        }
     


    }
    private void FixedUpdate()
    {
  
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineofSite, 0, player);

        Debug.Log("Durum1Gr"+checkingGround+"Durum2W"+checkingWall+"Durum3isGr"+isGrounded+"canSee"+canSeePlayer);
       
     
        if (!canSeePlayer&&isGrounded)
        {
            Patrolling();

        }
       else if(canSeePlayer)
        {
            rb.isKinematic = false;
            FlipTowardsPlayer();
            JumpAttack();
        }
            








    }
    void JumpAttack()
    {
        transform.rotation=Quaternion.Euler(Vector3.zero);
        if (isGrounded)
        {
            isJump = true;
            rb.AddForce(Vector2.up* jumpHeight, ForceMode2D.Impulse);
            

        }
        
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.transform.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.transform.position, circleRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.transform.position, boxSize);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, lineofSite);
    }
    void Patrolling()
    {
        Invoke(nameof(SetPhysicVal),0.5f);
        if (!(checkingGround || checkingWall))
        {
            isPatrol = false;
            if (!facingRight)
            {
                Flip();
            }
            else if(facingRight) {
                Flip();
            }
            
        }
        isPatrol=true;
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }
    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 0, 180);
        groundGameObject.transform.localPosition = new Vector3(-groundGameObject.transform.localPosition.x,
            -defaultCheckVal, groundGameObject.transform.localPosition.z);
        wallGameObject.transform.localPosition = new Vector3(-wallGameObject.transform.localPosition.x, -defaultCheckVal2,
            wallGameObject.transform.localPosition.z);
    }
    void FlipTowardsPlayer()
    {
        float playerPosition = playerT.position.x - transform.position.x;
           if (playerPosition < 0 && facingRight)
            {
                Flip();
            }
            else if (playerPosition > 0 && !facingRight)
            {
                Flip();
            }
        
     
    }

    void SetPhysicVal()
    {
        _collider2D.enabled = false;
        rb.isKinematic = true;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }*/

    float generateRandomVal(float health)
    {
        float randomVal;
        if (health <= 500 && health >= 300)
        {
            randomVal = Random.Range(randomMed, randomMax);
        }
        else if (health < 300 && health >= 100)
        {
            randomVal = Random.Range(randomMin, randomMed);
        }
        else
        {
            randomVal = Random.Range(0, randomMin);
        }

        return randomVal;
    }
    private void OnAnimatorMove()
    {
        anim.SetBool("isJump", isJump);
        
    }



}

