using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralHealth : MonoBehaviour
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
        LevelManage levelManager = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        int health = player.GetComponent<PlayerHealth>().initialHealth;

        // Deactivate all health bar segments
        for (int i = 0; i < gameObject.transform.childCount-3; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        // Activate the correct number of health bar segments
        for (int j = 0; j < health; j++)
        {
            gameObject.transform.GetChild(j).gameObject.SetActive(true);
        }

        if (health <= 0)
        {
            dead = true;
            levelManager.dead = dead;
            player.GetComponent<PlayerHealth>().Invoke("endLevelShowUI", 0.5f);
            player.GetComponent<BasicMech>().enabled = false;
            Destroy(player, 0.5f);
            healthBar.gameObject.SetActive(false);
        }
    }
}