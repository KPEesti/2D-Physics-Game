using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private int sceneIndex;
    private int levelComplete;
    
    void Start()
    {
        if (instance == null)
            instance = this;
        //instance ??= this;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void EndLevel()
    {
        if (sceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Invoke("LoadMainMenu", 0f);
            PlayerPrefs.DeleteAll();
        }
        else
        {
            if (levelComplete < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("NextLevel", 0f);
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("_Menu");
    }
}
