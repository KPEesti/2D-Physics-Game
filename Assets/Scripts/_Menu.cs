using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _Menu : MonoBehaviour
{
    public Button level2;
    private int levelComplete;
    private int sceneCount;
    

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        sceneCount = SceneManager.sceneCountInBuildSettings;
        
    }

    public void LoadNextLevel()
    {
        var nextLevel = levelComplete + 1 < sceneCount ? levelComplete + 1 : 0;
        SceneManager.LoadScene(nextLevel);
    }

    public void GoToLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
