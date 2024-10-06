using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMaech : MonoBehaviour
{
    // Start is called before the first frame update
    public float riseForce = 5f; // Yükselme kuvveti
    public float maxRiseDuration = 5f; // Maksimum yükselme süresi (5 saniye)
    public float cooldownDuration = 5f; // Cooldown süresi (5 saniye)

    private Rigidbody2D rb;
    private float riseTime = 0f; // Yükselme süresi
    private float cooldownTime = 0f; // Cooldown zamanlayıcısı
    private bool isOnCooldown = false;
    bool canUseJetpack;
    [SerializeField] GameObject fuel;

    void Start()
    {
        canUseJetpack = true;
       
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canUseJetpack)
        {
            if (isOnCooldown)
            {
                // Cooldown süresini takip et
                cooldownTime -= Time.deltaTime;
                if (cooldownTime <= 0f)
                {
                    isOnCooldown = false; // Cooldown bitti, tekrar kullanabilsin
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    if (riseTime < maxRiseDuration)
                    {
                        // Yükselme kuvveti uygula
                        rb.AddForce(Vector2.up * riseForce, ForceMode2D.Force);
                        riseTime += Time.deltaTime; // Yükselme süresini arttır
                    }
                    else
                    {
                        // Yükselme süresi doldu, cooldown başlat
                        StartCooldown();
                    }
                }
                else if (riseTime > 0f)
                {
                    // Eğer tuşu bıraktıysan ve hala sürem varsa, sayacı sıfırla
                    riseTime = 0f;
                }
            }
        }
       
        
    }

    void StartCooldown()
    {
        isOnCooldown = true;
        cooldownTime = cooldownDuration;
        riseTime = 0f; // Yükselme süresini sıfırla
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pool"))
        {
            canUseJetpack = true;
            fuel.SetActive(false);

        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pool"))
        {
            canUseJetpack = false;
            fuel.SetActive(true);
        }
    }
}
