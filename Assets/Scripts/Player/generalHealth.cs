using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class generalHealth : MonoBehaviour
{
    bool dead;
    public GameObject player, healthBar;
    bool isInArea;
    // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelManage d = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        int health = player.GetComponent<PlayerHealth>().initialHealth;
        for (int i = 0; i <= gameObject.transform.childCount-health-1; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int j = health ; j > 0; j--)
        {
            gameObject.transform.GetChild(j-1).gameObject.SetActive(true);
        }
        if(health == 0)
        {
            for(int i = 0;i<3;i++)
            {
              gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            dead= true;
            d.dead = dead;
            player.GetComponent<PlayerHealth>().Invoke("endLevelShowUI", 0.5f);
            player.GetComponent<BasicMech>().enabled = false;
            Destroy(player,0.5f);
            healthBar.gameObject.SetActive(false);
        }
    }
}
