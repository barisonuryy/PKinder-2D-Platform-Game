using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyEnemyMech : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float riseSpeed;
    public GameObject bullet;
    private float shotCoolDown;
    private bool isCollide;
    public float startShootCoolDown;
    [SerializeField] private PortalsSystem ps;
    [SerializeField] private level4 ps1;
    private Rigidbody2D flyRb;
    [SerializeField] private Transform upSidePlatform;
    [SerializeField] Level2EnemySystem enemySystem;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        flyRb = GetComponent<Rigidbody2D>();
        isCollide = false;
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            upSidePlatform = GameObject.Find("upSidePlatform").transform;
        }
        player = GameObject.FindWithTag("Player").transform;
        shotCoolDown = startTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isCollide)
        {
            Vector3 newPosition = transform.position + new Vector3(0, riseSpeed, 0) * Time.deltaTime;
            flyRb.MovePosition(newPosition);
        }
        if (player != null)
        {

            Vector2 direction = new Vector2(player.position.x - transform.position.x,
                player.position.y - transform.position.y);
            transform.up = direction;
            if (ps != null)
            {
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
            if (ps1 != null)
            {
                if (ps1.playerIsIn)
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

            if (SceneManager.GetActiveScene().name == "Level5")
            {
                if (!(upSidePlatform.position.y > transform.position.y))
                {
                    isCollide = true;
                }
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
            else
            {
                isCollide = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isCollide = true;
       
    }
    private void OnDestroy()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            enemySystem.increaseGroup1();
        }
    }
}
