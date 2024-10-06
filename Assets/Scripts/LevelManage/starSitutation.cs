using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        
        Finish p = GameObject.Find("Finish").GetComponent<Finish>();
        passed=p.passed;
        LevelManage d = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        dead=d.dead;
      
            if (passed)
            {

                if (SceneManager.GetActiveScene().buildIndex != 5)
                {
                    transform.Find("ContinueButton").gameObject.SetActive(true);

                }
                else
                    transform.Find("Finish Text").gameObject.SetActive(true);
            }
         
        
        if (dead)
        {
            transform.Find("Fail").gameObject.SetActive(true);

        }




    }

 
    
    
}
