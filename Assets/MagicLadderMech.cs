using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLadderMech : MonoBehaviour
{
    [SerializeField] private energyControl _energyControl;

    private bool isStarted;
    // Start is called before the first frame update
    void Start()
    {
        isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (_energyControl.isEnergy&&isStarted)
        {
            StartCoroutine(openTile());
          
        }
    }

    IEnumerator openTile()
    {
        isStarted = false;
        
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                StartCoroutine(gameObject.GetComponent<FadeInFadeOut>()
                    .FadeIn(gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>()));
                yield return new WaitForSeconds(0.25f);
            }
            

    }
}
