using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject leaderBoardScreen;
    [SerializeField] private GameObject marketScreen;

    [SerializeField] private bool soundPrefBool;
    [SerializeField] private bool vibrationPrefBool;

    [SerializeField] private Button soundButton;
    [SerializeField] private Sprite noSound;
    [SerializeField] private Sprite withSound;

    [SerializeField] private Button vibButton;
    [SerializeField] private Sprite noVib;
    [SerializeField] private Sprite withVib;

    public int sound;
    public int vib;

    private void Start()
    {
        SetPlayerPrefs();
    }
    private void Update()
    {
        
        CheckImages();
        PlayerPrefsUpdate();
        //sound =PlayerPrefs.GetInt("soundPref");
        //vib = PlayerPrefs.GetInt("vibrationPref");

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene 1");
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

    public void OpenMarket()
    {
        mainMenu.SetActive(false);
        marketScreen.SetActive(true);
    }
    public void BackButtonMarket()
    {
        mainMenu.SetActive(true);
        marketScreen.SetActive(false);
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

    public void SoundSetting()
    {
        soundPrefBool = !soundPrefBool;

        
    }
    public void VibrationSetting()
    {
        vibrationPrefBool = !vibrationPrefBool;

        
    }

    public void CheckImages()
    {
        if (soundPrefBool)
        {
            soundButton.GetComponent<Image>().sprite = withSound;
        }
        if (!soundPrefBool)
        {
            soundButton.GetComponent<Image>().sprite = noSound;
        }
        if (vibrationPrefBool)
        {
            vibButton.GetComponent<Image>().sprite = withVib;
        }
        if (!vibrationPrefBool)
        {
            vibButton.GetComponent<Image>().sprite = noVib;
        }
    }
    public void PlayerPrefsUpdate()
    {
        if (vibrationPrefBool)
        {
            PlayerPrefs.SetInt("vibrationPref", 1);
            vib = PlayerPrefs.GetInt("vibrationPref");
        }
        if (!vibrationPrefBool)
        {
            PlayerPrefs.SetInt("vibrationPref", 0);
            vib = PlayerPrefs.GetInt("vibrationPref");
        }
        if (soundPrefBool)
        {
            PlayerPrefs.SetInt("soundPref", 1);
            sound = PlayerPrefs.GetInt("soundPref");

        }
        if (!soundPrefBool)
        {
            PlayerPrefs.SetInt("soundPref", 0);
            sound = PlayerPrefs.GetInt("soundPref");

        }
    }

    public void SetPlayerPrefs()
    {
        if (PlayerPrefs.GetInt("soundPref") == 1)
        {
            soundPrefBool = true;
        }
        if (PlayerPrefs.GetInt("soundPref") == 0)
        {
            soundPrefBool = false;
        }
        if (PlayerPrefs.GetInt("vibrationPref") == 1)
        {
            vibrationPrefBool = true;
        }
        if (PlayerPrefs.GetInt("soundPref") == 0)
        {
            vibrationPrefBool = false;
        }
    }

}
