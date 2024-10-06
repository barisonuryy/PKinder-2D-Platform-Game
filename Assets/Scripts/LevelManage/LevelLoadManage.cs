using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadManage : MonoBehaviour
{
    [SerializeField] private GameObject mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel1()
    {
        mainCharacter.GetComponent<PlayerHealth>().SaveHealthValues();
        SceneManager.LoadScene("FirstLevel");
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
