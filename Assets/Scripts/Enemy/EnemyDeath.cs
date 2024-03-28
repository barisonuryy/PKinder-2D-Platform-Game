using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour

{
    [SerializeField] private GameObject cat,smoke,score;

    [SerializeField]
    private LevelManage _levelManage;
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            smoke.SetActive(true);
            smoke.transform.position=cat.transform.position;
            Destroy(cat);
      
        }
    }

    private void OnDestroy()
    {
        _levelManage.score += 50;
        score.GetComponent<Animator>().SetBool("scoreIncrease",true);



    }
}
