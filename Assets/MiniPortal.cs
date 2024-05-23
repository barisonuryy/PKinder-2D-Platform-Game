using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPortal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerPos;
    private bool isComplete;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hiyerarşideki yeri"+gameObject.transform.GetSiblingIndex());
    }

    private void ResetPortal()
    {
        isComplete = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.transform.GetSiblingIndex() == 0&&!isComplete)
        {
            playerPos.transform.position = gameObject.transform.parent.GetChild(1).position;
            isComplete = true;
            Invoke(nameof(ResetPortal),1f);
        }
        else if (gameObject.transform.GetSiblingIndex() == 1&&!isComplete)
        {
            playerPos.transform.position = gameObject.transform.parent.GetChild(0).position;
            isComplete = true;
            Invoke(nameof(ResetPortal),1f);
        }
    }
}
