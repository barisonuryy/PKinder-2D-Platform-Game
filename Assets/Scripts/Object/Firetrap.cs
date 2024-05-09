using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [SerializeField] bool triggered; 
    [SerializeField] bool active; 

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());
            if (active)
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
    private IEnumerator ActivateFiretrap()
    {
       
        triggered = true;
        spriteRend.color = Color.red; 
        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("activated", true);
        spriteRend.color = Color.white;

        yield return new WaitForSeconds(activeTime);
        active = false;

        triggered = false;
        anim.SetBool("activated", false);
    }
}