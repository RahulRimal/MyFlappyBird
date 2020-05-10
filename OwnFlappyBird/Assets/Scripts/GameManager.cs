using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject resumeButton;
    public GameObject pauseButton;

    public AudioSource buttonSound;

    void Start()
    {
        resumeButton.SetActive(false);
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void PlaySound()
    {
        buttonSound.Play();
    }
    
    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }


    public void BackToMain()
    {
        // SceneManager.LoadScene(0);

        SceneManager.LoadScene(0);
    }


    public void LoadScreen()
    {
        // SceneManager.LoadScene(0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        scoreManager.scoreOnStart = 0;
        
    }
}
