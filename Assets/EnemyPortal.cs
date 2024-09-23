using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    public delegate void PortalDestroyed();
    public event PortalDestroyed OnPortalDestroyed;
    [SerializeField] private AnimationClip enemyPortalClip;

    private void Start()
    {
        float time = enemyPortalClip.length;
        Invoke(nameof(DestroyPortal),time);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Oyuncu carptıx");
        if (other.CompareTag("Player"))
        {
            
            // Oyuncu portala vurduysa
            DestroyPortal();
        }
    }



    void DestroyPortal()
    {
        OnPortalDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
