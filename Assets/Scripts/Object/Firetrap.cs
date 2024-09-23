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
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());
            if (active)
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Trex"))
        {
           DeactivateObject();
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