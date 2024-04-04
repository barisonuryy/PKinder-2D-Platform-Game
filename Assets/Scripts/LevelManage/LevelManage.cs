using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class LevelManage : MonoBehaviour
{
    // Start is called before the first frame update

    bool p;
    public AudioSource bgm;
    public AudioSource PauseClick;
    public int score;
    public bool dead;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private Slider[] volumeSlider;
     public AudioSource[] audioSource;
     

    void Start()
    {
        for(int i=0;i<audioSource.Length;i++)
        volumeSlider[i].onValueChanged.AddListener(delegate { ChangeVolume(); });
     
    }
    public void ChangeVolume()
    {
        for(int i=0;i<audioSource.Length;i++)
        audioSource[i].volume = volumeSlider[i].value;
    }

    // Update is called once per frame
    void Update()
    {
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

    IEnumerator RestartGameOrder()
    {
        StartCoroutine(GetComponent<FadeInFadeOut>().FadeIn(mainCharacter.GetComponent<SpriteRenderer>()));
        yield return new WaitForSeconds(1f);
        StartCoroutine(GetComponent<FadeInFadeOut>().FadeOut(mainCharacter.GetComponent<SpriteRenderer>(),-0.05f));
        yield return new WaitForSeconds(1f);
       
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(mainCharacter.GetComponent<PlayerHealth>().DecreaseGeneralHealth());
            SceneManager.LoadScene((SceneManager.GetActiveScene().name));
        }
      
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
