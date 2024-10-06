using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EnemySystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] group1, group2, group3;
    [SerializeField] GameObject key1, key2, key3;
    [SerializeField] LevelManage levelManage;
    [SerializeField] GameObject[] openGate, closeGate;
    bool isCompleted,isCompleted2;
    int group1Val,keyCount;
    bool minoDead;
    void Start()
    {
        group1Val = 0;  
        keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(group1Val == group1.Length&&!isCompleted)
        {
            key1.SetActive(true);
            isCompleted = true;
        }
        if (minoDead&&!isCompleted2)
        {
            Debug.Log(minoDead+" aaaa");
            key3.gameObject.SetActive(true);
            isCompleted2 = true;
        }
          


        if (keyCount == 3)
        {
        
            StartCoroutine(openGates());
        }
            
        
    }
    public void increaseGroup1()
    {
        group1Val++;
    }
    public void minoDie()
    {
       minoDead = true;
    }
    public void increaseKeyCount()
    {
        keyCount++;
    }
    IEnumerator  openGates()
    {
        foreach (var go in closeGate)
        {
            levelManage.GetComponent<FadeInFadeOut>().FadeOut(go.GetComponent<SpriteRenderer>(), -0.05f);
            yield return new WaitForSeconds(0.5f);
            go.gameObject.SetActive(false);

        }

        yield return new WaitForSeconds(3);
        foreach(var go in openGate)
        {
            go.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            levelManage.GetComponent<FadeInFadeOut>().FadeIn(go.GetComponent<SpriteRenderer>());
        }
         

    }
}
