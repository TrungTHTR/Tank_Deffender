using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject thanksForplay;
    public GameObject pauseMenu;
    public GameObject GameOverMenu;
    public bool isPaused;
    private GameManager gameManager;
    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }
    void Start()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
        pauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        thanksForplay.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void BackMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Time.timeScale = 1f;
        GameOverMenu.SetActive(true);
        isPaused = true;
    }

    public void ThanksForPlay()
    {
        Time.timeScale = 1f;
        thanksForplay.SetActive(true);
        isPaused = true;
    }
   

    public void Restart()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
