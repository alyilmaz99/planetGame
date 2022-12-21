using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private ADManager adManager;

    [SerializeField] private GameObject endScreen;

    [SerializeField] private GameObject pauseScreen;




    void Start()
    {
       
    }

    
    void Update()
    {
        EndScreen();
       
    }

    public void EndScreen()
    {
        if (playerControl.endCheck)
        {
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!playerControl.endCheck)
        {
            endScreen.SetActive(false);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void EndScreenNoThanksButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene("GameScene 1"); 
    }

    public void RebornandContinueTheGame()
    {
        endScreen.SetActive(false);
        adManager.WatchRebornAd();
    }

}
