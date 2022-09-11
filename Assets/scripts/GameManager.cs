using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    
    public GameObject gameOverScreen;

    

    private void Awake()
    {
        gameOver = false;
    }

    void Update()
    {
        gameOverScreenActive();
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void QuitLevelHard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void QuitLevelEasy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void gameOverScreenActive()
    {
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
   
}
