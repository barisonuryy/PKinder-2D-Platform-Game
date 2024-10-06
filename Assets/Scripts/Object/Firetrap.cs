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
    public TrexTrapMech spawner; // Spawner referansı

    public void DeactivateObject()
    {
        gameObject.SetActive(false); // Objeyi pasif hale getir
        if (spawner != null)
        {
            spawner.StartCoroutine(spawner.RespawnObject()); // Yeniden etkinleştirme işlemini başlat
        }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());
            if (active)
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Trex"))
        {
            Invoke(nameof(DeactivateObject), 2);
            
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Trex"))
        {
            if (active)
            collision.GetComponent<TrexHealth>().TakeDamageTrex(15);
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