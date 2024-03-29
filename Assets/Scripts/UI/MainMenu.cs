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
    [SerializeField] private Button market;

    [SerializeField] private bool soundPrefBool;
    [SerializeField] private bool vibrationPrefBool;



    [SerializeField] private Sprite withSound;
    [SerializeField] private Sprite withVib;

    public int sound;
    public int vib;


    [Header("No Ads")]
    [SerializeField] private GameObject noAdsButton;
    [SerializeField] private GameObject noAdsButton2;

    [SerializeField] private int adsCheck;
    [SerializeField] private bool adsReset;


    [Header("sound/Vib Settings")]
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject vibButton;
    [SerializeField] private List<Sprite> soundSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> vibSpriteList = new List<Sprite>();
    [SerializeField] private bool soundFixer;
    [SerializeField] private bool vibFixer;

    private void Start()
    {
        StartSoundVibCheck();
    }
    private void Update()
    {
        // ads butonu testi i�in. Oyun i�erisinden etkile�imi yok. Inspector men�den d�zeltiliyor
        SoundVibUpdate();
        if (adsReset)
        {
            PlayerPrefs.SetInt("noads", 0);
            adsCheck = PlayerPrefs.GetInt("noads");
        }

        
        

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene 1");
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
        market.gameObject.SetActive(false); 
    }
    public void BackButtonMarket()
    {
        mainMenu.SetActive(true);
        marketScreen.SetActive(false);
        market.gameObject.SetActive(true);
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

   
    #region Noads

    private void SetAdsCheck()
    {
        adsCheck = PlayerPrefs.GetInt("noads");

        if (adsCheck == 1)
        {
            noAdsButton.gameObject.SetActive(false);
            noAdsButton2.gameObject.SetActive(true);


        }
        else
        {
            noAdsButton.gameObject.SetActive(true);
            noAdsButton2.gameObject.SetActive(false);
        }
    }

    public void noAdsBuyButton()
    {
        Debug.Log("satin alindi reklamsiz oyun");
        PlayerPrefs.SetInt("noads", 1);
        adsCheck = PlayerPrefs.GetInt("noads");
        SetAdsCheck();

    }

    #endregion


    public void SoundVibUpdate()
    {
        if (soundFixer)
        {
            PlayerPrefs.SetInt("sound", 1);
            soundButton.GetComponent<Image>().sprite = soundSpriteList[1];
        }
        else if (!soundFixer)
        {
            PlayerPrefs.SetInt("sound", 0);
            soundButton.GetComponent<Image>().sprite = soundSpriteList[0];
        }

        if (vibFixer)
        {
            PlayerPrefs.SetInt("vib", 1);
            vibButton.GetComponent<Image>().sprite = vibSpriteList[1];
        }
        else if (!vibFixer)
        {
            PlayerPrefs.SetInt("vib", 0);
            vibButton.GetComponent<Image>().sprite = vibSpriteList[0];
        }

    }


    public void StartSoundVibCheck()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundFixer = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundFixer = false;
        }

        if (PlayerPrefs.GetInt("vib") == 1)
        {
            vibFixer = true;
        }
        else if (PlayerPrefs.GetInt("vib") == 0)
        {
            vibFixer = false;
        }
    }

    public void SoundButton()
    {
        soundFixer = !soundFixer;
    }
    public void VibButton()
    {
        vibFixer = !vibFixer;
    }
}
