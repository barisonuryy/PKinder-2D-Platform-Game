using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float CharacterScale;
    // Start is called before the first frame update
    private Vector2 checkPointPos;
    private Rigidbody2D playerRb;
    [SerializeField] private Light2D lt;
    [SerializeField] private GameObject[] hideObjects;
    [SerializeField] private LevelManage _levelManage;
    private bool invicible;
    public Finish p;
    public float health = 100; 
    public  float maxHealth = 100;
    public int initialHealth = 3;
    int bigPotion = 3;
    int smallPotion = 3;
    [SerializeField] GameObject g;
    private SpriteRenderer rend;
    public GameObject endLevelUI;
   GameObject endLevelStars;
   private bool takeDamaged;
   private SpriteRenderer backgroundSprite;

     void Start()
     {
         checkPointPos = transform.position;
         playerRb = GetComponent<Rigidbody2D>();
         invicible = false;
         if (PlayerPrefs.GetFloat("playerHealth") != maxHealth&&PlayerPrefs.GetFloat("playerHealth") != 0)
         {
             health = PlayerPrefs.GetFloat("playerHealth");
         }
        if (PlayerPrefs.GetInt("generalHealth") <= 0)
        {
            initialHealth = 3;
        }
        else
        {
            initialHealth = PlayerPrefs.GetInt("generalHealth");
        }
    rend=GetComponent<SpriteRenderer>();
    }
    void Update()
    {
       
       
        if(health <=0) {
           health = maxHealth;
           DecreaseGeneralHealth();
           
        }
        if (Input.GetKeyDown(KeyCode.P)&&bigPotion>0)
        {
            health += 40;
            if(health>100)
            {
                health-=100;
                initialHealth++;

            }
            bigPotion--;
        }
            
        if (Input.GetKeyDown(KeyCode.O) && smallPotion > 0)
        {
            health += 10;
            if (health > 100)
            {
                health -= 100;
                initialHealth++;
            }
            smallPotion--;
        }

        if (p != null)
        {
            if (p.passed)
            {
            
                Invoke("DestroyObj", 1.5f);
                Invoke("endLevelShowUI", 2.74f);
            }
        }
          
    
        else if(_levelManage!=null&&_levelManage.dead)
        {
            Invoke("endLevelShowUI", 1f);
        }

        
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
    }


    private void DestroyObj()
    {
        if (Vector2.Distance(transform.position, g.transform.position) < 100)
        {
            StartFading();
            Destroy(gameObject, 1.25f);
            
        }
    }
    IEnumerator FadeOut()
    {
        for(float f = 1.0f; f >=-0.05f; f -= 0.05f) {
        Color c=rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
       
    }
    IEnumerator LightOn(float lightFinalVal)
    {
        for(float f = 0f; f <1f; f += 0.05f) {
            lt.intensity =f;
            yield return new WaitForSeconds(0.05f);
        }

       

    }
    IEnumerator LightOff(float lightInitVal)
    {
        for(float f = lightInitVal; f >=-0.05f; f -= 0.05f) {
            lt.intensity = f;
            yield return new WaitForSeconds(0.05f);
        }
       
    }

   public IEnumerator Respawn(float duration)
   {
        if (gameObject != null)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.simulated = false;
            transform.localScale = Vector3.zero;
            yield return new WaitForSeconds(duration);
            transform.position = checkPointPos;
            transform.localScale = new Vector3(CharacterScale, CharacterScale, 1);
            playerRb.simulated = true;
            gameObject.GetComponent<BasicMech>().SetRespawnFlip();
        }
   }

    public void SetCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }
    public void endLevelShowUI()
    {
       
        endLevelUI.SetActive(true);
        foreach (var objects in hideObjects)
        {
            objects.SetActive(false);
        }
        
        
    }
    public void StartFading()
    {
        StartCoroutine(FadeOut());
    }
    public void activateAnimator()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().Play("Base Layer.penguin_idle", 0, 0);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("CatEnemy"))
        {
            health -= 0.25f;
            TakeDamageP(true);
      

        }
    }

    public void SaveHealthValues()
    {
        PlayerPrefs.SetFloat("playerHealth",health);
        PlayerPrefs.SetInt("generalHealth",initialHealth);
        PlayerPrefs.Save();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(2);
        }
        if (other.gameObject.name == "MaceBlack")
        {
            TakeDamage(4);
        }
        if(other.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(3);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("ObstacleLevel4"))
        {
            TakeDamage(4);
        }


    }


    public void TakeDamageP(bool isPunched)
    {
        takeDamaged = isPunched;
     
    }

    public void TakeDamage(float healthP)
    {
        health -= healthP;
        
    }
    


public void DecreaseGeneralHealth()
{
        initialHealth--;
        SaveHealthValues();
        /*invicible = true;
        StartCoroutine(LightOff(0.9f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(LightOn(0.9f));
        yield return new WaitForSeconds(3f);
        invicible = false;*/
}

   

 

 




}
