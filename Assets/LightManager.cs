using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Light2D globalLight;
    private float targetIntensity; // The target intensity value
    public float changeSpeed = 1f; // Speed at which the light changes intensity

    void Start()
    {
        globalLight = GetComponent<Light2D>();
        targetIntensity = globalLight.intensity; // Set initial target intensity to current intensity
    }

    void Update()
    {
        // Smoothly move the current intensity towards the target intensity
        globalLight.intensity = Mathf.MoveTowards(globalLight.intensity, targetIntensity, changeSpeed * Time.deltaTime);
    }

    public void openLight()
    {
        // Set target intensity to 1 to smoothly increase the light intensity
        targetIntensity = 1f;
    }

    public void closeLight()
    {
        // Set target intensity to 0 to smoothly decrease the light intensity
        targetIntensity = 0f;
    }
}