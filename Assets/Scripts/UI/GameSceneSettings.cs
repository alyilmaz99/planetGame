using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneSettings : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private Image retryImage;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private int fillAmountSpeed;




    #region Sound
    [Header("sound/Vib Settings")]
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject vibButton;
    [SerializeField] private List<Sprite> soundSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> vibSpriteList = new List<Sprite>();

    [SerializeField] private bool soundFixer;
    [SerializeField] private bool vibFixer;
    #endregion

    void Start()
    {
        StartSoundVibCheck();
        retryImage.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {

        SoundVibUpdate();
        if (playerControl.endCheck)
        {
            retryImage.fillAmount -= Time.unscaledDeltaTime/ fillAmountSpeed;
            if (retryImage.fillAmount <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }
        else 
        {
                retryImage.fillAmount = 1;
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


    #region Sound-Vib Controller

    public void SoundButton()
    {
        soundFixer = !soundFixer;
    }
    public void VibButton()
    {
        vibFixer = !vibFixer;
    }


    void SoundVibUpdate()
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


    void StartSoundVibCheck()
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

    #endregion



}
