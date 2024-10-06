using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jpMech : MonoBehaviour
{
    [SerializeField] float valX, valY;
    bool isTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTaken)
        {
            transform.Rotate(0,0,90*Time.deltaTime); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTaken = true;
            gameObject.transform.parent = collision.transform; 
            gameObject.transform.localPosition=new Vector3(valX,valY);
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
