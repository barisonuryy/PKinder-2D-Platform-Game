using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starSitutation : MonoBehaviour
{
    GameObject activableStar;
    GameObject disableStar;
    int score;
    bool passed;
    int index;
    bool dead;
   
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        LevelManage s=GameObject.Find("LevelManager").GetComponent<LevelManage>();
        score= s.score;
        Finish p = GameObject.Find("Finish").GetComponent<Finish>();
        passed=p.passed;
        LevelManage d = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        dead=d.dead;
        StartCoroutine(showStars(passed,score,dead));
    }
    private IEnumerator showStars(bool pass,int scr,bool isDead)
    {
        
        if (pass)
        {
           
            if (scr >= 150&&scr<250)
            {
                index = 0;
                defineStar(index+1, index + 4);
                yield return new WaitForSeconds(1.5f);
                defineStar(index+5,index+2);
                yield return new WaitForSeconds(1.5f);
                defineStar(index+6,index+3);
            }
            else if (scr >= 250 && scr < 350)
            {
                index = 0;
                for(int i = 1; i < 3; i++)
                {
                    defineStar(index+i,index+i+3);
                    yield return new WaitForSeconds(1.5f);
                }
                    defineStar(index + 6,index+3);
            }
            else if (scr >= 350)
            {
                index = 0;
                for(int i = 1; i < 4; i++)
                {
                    defineStar(index+i,index+i+3);
                    yield return new WaitForSeconds(1.5f);
                }
             
            }
        }
        if (isDead)
        {

            
            index = 3;
             for (int i = 1; i < 4; i++)
             {
                 defineStar(index + i, index + i - 3);
                 yield return new WaitForSeconds(1f);
             }
           
        }
    }
    private void defineStar(int x,int y)
    {
        activableStar = gameObject.transform.GetChild(x).gameObject;
        activableStar.SetActive(true);
        disableStar= gameObject.transform.GetChild(y).gameObject;
        disableStar.SetActive(false);
    }
    
    
}
