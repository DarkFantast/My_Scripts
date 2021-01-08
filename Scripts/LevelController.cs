using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    public static LevelController instance = null;
    int sceneIndex;
    int levelComplete;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame()
    {
        if (sceneIndex == 20)
        {
            Invoke("LoadMenu", 0.5f);
        }
        else
        {
            if (levelComplete < sceneIndex)
            PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("NextLevel", 0.5f);
        }
    }

   void NextLevel()
   {
       SceneManager.LoadScene(sceneIndex + 1);
   }

   void LoadMenu()
   {
       SceneManager.LoadScene("Menu");
   }
}
