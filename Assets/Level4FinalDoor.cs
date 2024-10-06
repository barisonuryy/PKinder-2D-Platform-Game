using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4FinalDoor : MonoBehaviour
{
    [SerializeField] TrexHealth trexHealth;
    [SerializeField] EnemyPortalMech enemyPortalMech;
     int trexCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void increaseTrexCount()
    {
        trexCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (trexCount == 5)
        {
            
            if (trexHealth.isDead && SceneManager.GetActiveScene().buildIndex == 4)
                transform.Translate(0, -1 * Time.deltaTime, 0);
        }
      
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            if(enemyPortalMech.isDestroyed)
            transform.Translate(0, 1 * Time.deltaTime, 0);
        }
    }
}
