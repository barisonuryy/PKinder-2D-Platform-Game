using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyControl : MonoBehaviour
{
    [SerializeField] private LaserMech[] _laser;
    private bool firstLaser, secondLaser, thirdLaser;
    private SpriteRenderer spriteRenderer; // Renk geçişini uygulayacağımız sprite renderer bileşeni

    public Color startColor = Color.white; // Başlangıç rengi (sarı)
    public Color endColor = Color.red; // Bitiş rengi (kırmızı)

    public float transitionDuration = 2f; // Geçiş süresi
    public  bool isEnergy;
    private float transitionTimer = 0f;
    
    public bool isCompleted;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isEnergy = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_laser[0].isInEnergyArea && _laser[1].isInEnergyArea && _laser[2].isInEnergyArea)
        {
            isEnergy = true;
            Debug.Log("OLDUU");
            transitionTimer += Time.deltaTime;

            // Yumuşak bir geçiş yapmak için, Lerp fonksiyonunu kullanarak ara bir renk hesapla
            Color lerpedColor = Color.Lerp(startColor, endColor, transitionTimer / transitionDuration);

            // Nesnenin rengini güncelle
            spriteRenderer.color = lerpedColor;

            // Geçiş tamamlandığında, sayaçı sıfırla ve döngüyü tekrar et
            if (transitionTimer >= transitionDuration)
            {
                transitionTimer = 0f;
                // Başlangıç ve bitiş renklerini yer değiştirerek sürekli bir döngü elde edebilirsiniz.
                Color temp = startColor;
                startColor = endColor;
                endColor = temp;
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Giriş"+other.gameObject.name);
        /*if (other.gameObject.name == "Laser")
        {
            Debug.Log("Giriş1111");
            firstLaser = true;
        }
        if (other.gameObject.name == "ReverseLaser")
        {
            Debug.Log("Giriş22222");
            secondLaser = true;
        }
        if (other.gameObject.name == "ControllableLaser")
        {
            Debug.Log("Giriş3333");
            thirdLaser = true;
        }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Laser")
        {
            firstLaser = false;
        }
        if (other.gameObject.name == "ReverseLaser")
        {
            secondLaser = false;
        }
        if (other.gameObject.name == "ControllableLaser")
        {
            thirdLaser = false;
        }
    }

    /*IEnumerator changeColor()
    {
        Mathf.cla
        gameObject.GetComponent<SpriteRenderer>().color
    }*/
}
