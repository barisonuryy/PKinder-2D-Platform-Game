using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelegateCamera : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {

            if (gameObject.GetComponentInChildren<Canvas>() != null)
            {
                gameObject.GetComponentInChildren<Canvas>().worldCamera=Camera.main;
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
