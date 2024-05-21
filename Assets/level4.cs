using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerIsIn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsIn=true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsIn=false;
    }
}
