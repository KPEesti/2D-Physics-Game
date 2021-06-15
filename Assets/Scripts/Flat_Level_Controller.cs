using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flat_Level_Controller : MonoBehaviour
{
    private int _appleCount;

    public Collider2D ExitCollider;
    public static Flat_Level_Controller instance = null;
    private int sceneIndex;
    private int levelComplete;

    void Start()
    {
        if (instance == null)
            instance = this;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }
    
    void Update()
    {
        if (_appleCount >= 3)
            ExitCollider.enabled = false;
    }

    public void UpdateAppleCount()
    {
        _appleCount++;
        Debug.Log($"Количество собранных тыблок - {_appleCount} / 3");
    }

    public void TaskMesage()
    {
        Debug.Log("Задание по сбору тыблок принято!!!");
    }

    public void IsEndGame()
    {
        if (sceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (levelComplete < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("NextLevel", 1f);
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("_Menu");
    }
}
