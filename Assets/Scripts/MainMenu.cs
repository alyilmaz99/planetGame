using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject leaderBoardScreen;


    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLeaderBoard()
    {
        mainMenu.SetActive(false);
        leaderBoardScreen.SetActive(true);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void BackButtonSettings()
    {
        settingsScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void BackButtonLeaderBoard()
    {
        leaderBoardScreen.SetActive(false);
        mainMenu.SetActive(true);
    }





}
