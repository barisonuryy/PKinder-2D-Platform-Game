using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMech : MonoBehaviour
{
    public Transform player;
    
    public GameObject bullet;
    private float shotCoolDown;

    public float startShootCoolDown;
    [SerializeField] private PortalsSystem ps;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        shotCoolDown = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x,
            player.position.y - transform.position.y);
        transform.up = direction;
        if (ps.playerIsIn)
        {
            if (shotCoolDown <= 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                shotCoolDown = startShootCoolDown;
            }
            else
            {
                shotCoolDown -= Time.deltaTime;
            }
        }
  
      
    }
    
}
