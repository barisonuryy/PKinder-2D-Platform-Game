using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tRexDamageEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    float dir;
    float initialPower;
    [SerializeField] float power;
    [SerializeField] BasicMech basicMech;
    void Start()
    {
        initialPower = power;
     
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        dir = gameObject.GetComponentInParent<TrexAttack>().moveDirection;
        if (collision.CompareTag("Player"))
        {

            collision.GetComponent<BasicMech>().canUseMovement = false;
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir * power * Time.deltaTime, 0), ForceMode2D.Impulse);
            // power = Mathf.Lerp(power, power - 10, Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&basicMech.isGrounded())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<BasicMech>().canUseMovement = true;
            power = initialPower;

        }
    }
    
}
