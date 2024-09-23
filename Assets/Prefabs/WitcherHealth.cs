using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class WitcherHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int witcherHealth = 100;
     public int witcherMaxHealth = 100;
    [SerializeField] GameObject smoke;
    private bool isDead;
    
    
    [SerializeField] ParticleSystem prt;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        isDead = false;
        
     
        
    }

    private void Update()
    {
  
        GetComponentInChildren<MinoHealthUI>().setHealthUI(witcherHealth,witcherMaxHealth);
        
    }

    public void TakeDamageWitcher(int damage)
    {
        witcherHealth -= damage;
        if (witcherHealth <= 0&&!isDead)
        {
            GetComponent<witcherMovement>().enabled = false;
            GetComponent<WitcherScriptControl>().enabled = false;
            Destroy(gameObject,1f);
            isDead = true;
        }
        
    }

    private void OnDestroy()
    {
        smoke.SetActive(true);
        smoke.transform.position=transform.root.position;
    }
    public void IncreaseHealth(float incHealth)
    {
        if (witcherHealth < witcherMaxHealth)
        {
            witcherHealth += (int)(incHealth / witcherMaxHealth) * 100;
            setParticleState();
        }
        else
            witcherHealth = witcherMaxHealth;
     

    }

    async void setParticleState()
    {
        prt.Play();
        await Task.Delay(1500);
        prt.Stop();
    }
}
