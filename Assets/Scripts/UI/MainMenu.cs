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


    [Header("No Ads")]
    [SerializeField] private GameObject noAdsButton;
    [SerializeField] private GameObject noAdsButton2;

    [SerializeField] private int adsCheck;
    [SerializeField] private bool adsReset;


    private void Start()
    {
        

    }
    private void Update()
    {
        // ads butonu testi için. Oyun içerisinden etkileþimi yok. Inspector menüden düzeltiliyor

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

}
