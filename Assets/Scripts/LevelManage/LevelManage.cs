using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using Image = UnityEngine.UI.Image;

public class LevelManage : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerHealth h;
    bool p;
    public AudioSource bgm;
    public AudioSource PauseClick;
    public int score;
    public bool dead;
    public bool isFalled;
    [SerializeField] private GameObject mainCharacter;

    void Start()
    {
     
     
     
    }

    // Update is called once per frame
    void Update()
    {
     

       



        // Orijinal d��menin �zelliklerini yeni d��meye kopyalay�
        p = GetComponentInChildren<Finish>().passed;
        if (PlayerPrefs.GetInt("generalHealth") == 0)
        {
            //SceneManager.LoadScene("SampleScene");
            dead = true;
        }
  
        if (p)
        {
            bgm.Stop();
        }
     
 
      
     
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFalled = true;
            SceneManager.LoadScene((SceneManager.GetActiveScene().name));

        }
        else isFalled = false;
    }

    private void showScore(int score)
    {

    }
    private void playScoreAnim()
    {

    }

    public void StopCharacter()
    {
        if (mainCharacter != null)
        {
            mainCharacter.GetComponent<BasicMech>().enabled = false;
        }
    }

    public void PlayCharacter()
    {
        mainCharacter.GetComponent<BasicMech>().enabled = true;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void pauseClick()
    {
        PauseClick.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void exitGame()
    {
        Application.Quit();

    }
    public void backHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
