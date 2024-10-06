using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeLevelKey : MonoBehaviour
{
    [SerializeField] Level2EnemySystem enemySystem;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        enemySystem.increaseKeyCount();
    }
    private void Update()
    {
        transform.Rotate(0,0,60*Time.deltaTime);    
    }
}
