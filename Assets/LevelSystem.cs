using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Initializedd"))
        {
            PlayerPrefs.DeleteAll();  // İlk seferde tüm kayıtlı değerleri sıfırla
            PlayerPrefs.SetInt("Initializedd", 1);  // "Initialized" anahtarını ayarla
            PlayerPrefs.Save();  // Değişiklikleri kaydet
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
Debug.Log(unlockedLevel);
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    private void Update()
    {
        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}