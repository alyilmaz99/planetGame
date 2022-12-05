using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneSettings : MonoBehaviour
{
    [SerializeField] private Button soundButton;
    [SerializeField] private Sprite noSound;
    [SerializeField] private Sprite withSound;

    [SerializeField] private Button vibButton;
    [SerializeField] private Sprite noVib;
    [SerializeField] private Sprite withVib;


    [SerializeField] private bool soundPrefBool;
    [SerializeField] private bool vibrationPrefBool;

    [SerializeField] private GameObject settingsScreen;

    public int gamesound;
    public int gamevib;



    void Start()
    {
        gamesound = PlayerPrefs.GetInt("soundPref");
        gamevib = PlayerPrefs.GetInt("vibrationPref");
        SetPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerBooleans();
        CheckImages();

        gamesound = PlayerPrefs.GetInt("soundPref");
        gamevib = PlayerPrefs.GetInt("vibrationPref");
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

    public void BackButtonGameSceneSettings()
    {

        settingsScreen.SetActive(false);
        
    }
    public void OpenSettingsInGameSceneSettings()
    {
        settingsScreen.SetActive(true);
    }

    void SetPlayerPrefs()
    {
        if (gamesound == 1)
        {
            soundPrefBool = true;
        }
        else if(gamesound == 0)
        {
            soundPrefBool = false;
        }
        if (gamevib == 1)
        {
            vibrationPrefBool = true;
        }
        else if (gamevib == 0)
        {
            vibrationPrefBool = false;
        }
    }

    void SetPlayerBooleans()
    {
        if (soundPrefBool)
        {
            PlayerPrefs.SetInt("soundPref", 1);
        }
        if (!soundPrefBool)
        {
            PlayerPrefs.SetInt("soundPref", 0);
        }
        if (vibrationPrefBool)
        {
            PlayerPrefs.SetInt("vibrationPref", 1);
        }
        if (!vibrationPrefBool)
        {
            PlayerPrefs.SetInt("vibrationPref", 0);
        }
    }

    

    

    
}
