using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadManager : MonoBehaviour
{
    private static LevelLoadManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel7SEvent()
    {
        
    }
}
