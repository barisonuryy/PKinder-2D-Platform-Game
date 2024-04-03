using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GoblinHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float goblinHealth = 100f;
    public float goblinMaxHealth = 100f;
    [SerializeField] GameObject smoke,score;
    private bool isDead;
    [SerializeField] private LevelManage _levelManage;
   
    
  

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        isDead = false;
        
     
        
    }

    private void Update()
    {
  
        GetComponentInChildren<MinoHealthUI>().setHealthUI(goblinHealth,goblinMaxHealth);
        
    }

    public void TakeDamageGoblin(float damage)
    {
        goblinHealth -= damage;
        if (goblinHealth <= 0&&!isDead)
        {
            GetComponentInChildren<goblinAttack>().enabled = false;
            Destroy(gameObject,1f);
            isDead = true;
        }
        
    }

    private void OnDestroy()
    {
        smoke.SetActive(true);
        smoke.transform.position=transform.root.position;
        _levelManage.score += 50;
        score.GetComponent<Animator>().SetBool("scoreIncrease",true);
        
    }
    public void IncreaseHealth(float incHealth)
    {
        if (goblinHealth < goblinMaxHealth)
        {
            goblinHealth += (incHealth / goblinMaxHealth) * 100;
           // setParticleState();
        }
        else
            goblinHealth = goblinMaxHealth;
     

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Snowball"))
        {
            TakeDamageGoblin(10);
            Destroy(other.gameObject);
        }
    }

   /* async void setParticleState()
    {
        prt.Play();
        await Task.Delay(1500);
        prt.Stop();
    }*/
}
