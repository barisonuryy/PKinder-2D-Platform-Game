using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
   public bool passed;
   [SerializeField] private GameObject mainCharacter;
    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            mainCharacter.GetComponent<BasicMech>().enabled= false;
            mainCharacter.GetComponent<Animator>().enabled = false;
            passed= true;


            //SceneManager.LoadScene("SecondScene");
        }
    }


}
