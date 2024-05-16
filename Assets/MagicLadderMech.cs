using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLadderMech : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(openTile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator openTile()
    {
        
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                StartCoroutine(gameObject.GetComponent<FadeInFadeOut>()
                    .FadeIn(gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>()));
                yield return new WaitForSeconds(0.25f);
            }
    
    }
}
