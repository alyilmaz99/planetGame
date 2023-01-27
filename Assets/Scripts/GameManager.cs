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

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseScreenButtons;

    [SerializeField] private GameObject scoreGameObject;




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

            pauseButton.SetActive(false);
            scoreGameObject.SetActive(false);

            Time.timeScale = 0;
            
            goldgiv();
        }
        else if (!playerControl.endCheck)
        {
            endScreen.SetActive(false);
        }
    }
    public void goldgiv(){
        //Debug.Log("fonksiyon deneme");
        var gold = GameObject.FindGameObjectWithTag("manager").GetComponent<goldgiver>();
        gold.goldgive();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
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
