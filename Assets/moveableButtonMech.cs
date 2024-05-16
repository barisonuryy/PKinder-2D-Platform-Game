using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class moveableButtonMech : MonoBehaviour
{
     bool canTurn;
     public bool isTurned;
    [SerializeField] private float rotVal;
    [SerializeField] private float rangeRot;
    [SerializeField] private Transform _transformRotator;

    private float initialRotation;
    private float currentRotation;
    private int rotationDirection = 1;
    void Start()
    {
        // Başlangıçta nesnenin dönme açısını al
        initialRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        if (canTurn)
        {
            currentRotation += rotVal * Time.deltaTime * rotationDirection;

            // Dönme sınırını kontrol et
            if (currentRotation > rangeRot || currentRotation < -rangeRot)
            {
                canTurn = false; // Dönme işlemi tamamlandı
                isTurned = !isTurned;
                rotationDirection *= -1; // Dönme yönünü tersine çevir
                currentRotation = Mathf.Clamp(currentRotation, -rangeRot, rangeRot); // Dönme sınırında tut
            }

            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            canTurn = true;
            _transformRotator.rotation=quaternion.Euler(Vector3.zero);

        }
    }
}