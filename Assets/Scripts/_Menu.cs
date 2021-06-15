using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _Menu : MonoBehaviour
{
    private int levelComplete;
    // Start is called before the first frame update
    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void LoadNextLevel()
    {
        var sceneCount = SceneManager.sceneCountInBuildSettings;
        var nextLevel = levelComplete + 1 < sceneCount ? levelComplete + 1 : 0;
        SceneManager.LoadScene(nextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
