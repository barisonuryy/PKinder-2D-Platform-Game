using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SandMechanic : MonoBehaviour
{
    private bool isDown;
    [SerializeField] private float counter, speed;
    private float downTime;
    
    // Start is called before the first frame update
    void Start()
    {
        downTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale+=Vector3.up*Time.deltaTime/speed;
    }

   

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            downTime += Time.deltaTime;
            if (downTime > counter)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            downTime = 0;
    }
}
