using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;

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

}
