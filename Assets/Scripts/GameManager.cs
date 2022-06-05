using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject WinGamePanel;
    [SerializeField] GameObject PauseGamePanel;

    private bool isStart = true;
    private bool isGameOver = false;
    private bool isWinGame = false;
    private bool isPause = false;

    public void Start()
    {
        GameOverPanel.SetActive(false);
        PauseGamePanel.SetActive(false);
        WinGamePanel.SetActive(false);
        Time.timeScale = 1f;
        Score._score = 0;
        isStart = true;
        isGameOver = false;
        isPause = false;
    }

    public void ResumeGame()
    {
        PauseGamePanel.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        PauseGamePanel.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Main");
        Score._score = 0;
    }

    public void WinGame()
    {
        WinGamePanel.SetActive(true);
        Time.timeScale = 0f;
        isWinGame = true;
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsWinGame()
    {
        return isWinGame;
    }    

    public bool IsPause()
    {
        return isPause;
    }

    public bool IsStart()
    {
        return isStart;
    }
}
