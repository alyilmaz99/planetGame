using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;

public class Market : MonoBehaviour
{
    [SerializeField] private int skinCheck;
    [SerializeField] private int skinCheckIndex;
    [SerializeField] private int gold;

    [SerializeField] private List<bool> buyCheck = new List<bool>();
    [SerializeField] private List<GameObject> buttonsList = new List<GameObject>();
    [SerializeField] private List<GameObject> buyButtonsList = new List<GameObject>();

    [SerializeField] private List<int> priceList = new List<int>();
    [SerializeField] private GameObject buyPanel;

    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private int priceGold=0;

    [Header("BuyGold")]
    [SerializeField] private GameObject buyGoldPanel;


    private void Start()
    {


        if (PlayerPrefs.HasKey("gold"))
        {
            gold = PlayerPrefs.GetInt("gold");
        }
        StartingSettings();


        skinCheck = PlayerPrefs.GetInt("Character");
    }

    private void Update()
    {

        goldText.text = gold.ToString();

        priceText.text = ("Do you want to buy this character for " + priceGold + " GOLD?");

        skinCheck = PlayerPrefs.GetInt("Character");
        ButtonsUpdate();

        PlayerPrefs.SetInt("gold",gold);

        UpdatePlayerPrefs();


    }
    #region SetSkin
    public void Character1()
    {
        PlayerPrefs.SetInt("Character", 1);
    }
    public void Character2()
    {
        PlayerPrefs.SetInt("Character", 2);
    }
    public void Character3()
    {
        PlayerPrefs.SetInt("Character", 3);
    }
    public void Character4()
    {
        PlayerPrefs.SetInt("Character", 4);
    }
    public void Character5()
    {
        PlayerPrefs.SetInt("Character", 5);

    }
    public void Character6()
    {
        PlayerPrefs.SetInt("Character", 6);
    }
    public void Character7()
    {
        PlayerPrefs.SetInt("Character", 7);
    }
    public void Character8()
    {
        PlayerPrefs.SetInt("Character", 8);
    }
    public void Character9()
    {
        PlayerPrefs.SetInt("Character", 9);
    }

    public void BuyGold()
    {
        Debug.Log("Gold satin alindiiii");
        
    }
    #endregion

    #region BuySkin
    public void BuyCharacter()
    {
        if (gold > priceGold)
        {
            gold -= priceGold;
            buyCheck[skinCheckIndex] = true;
            buyPanel.gameObject.SetActive(false);

        }
    }
    

    #endregion

    #region OpenBuyMenu

    public void OpenBuyMenu1()
    {        
        priceGold = priceList[0];

        skinCheckIndex = 0;

        buyPanel.gameObject.SetActive(true);
    }
    public void OpenBuyMenu2()
    {
        priceGold = priceList[1];

        skinCheckIndex = 1;

        buyPanel.gameObject.SetActive(true);
    }
    public void OpenBuyMenu3()
    {
        priceGold = priceList[2];

        skinCheckIndex = 2;

        buyPanel.gameObject.SetActive(true);
    }
    public void OpenBuyMenu4()
    {
        priceGold = priceList[3];

        skinCheckIndex = 3;

        buyPanel.gameObject.SetActive(true);
    }
    public void OpenBuyMenu5()
    {
        priceGold = priceList[4];

        skinCheckIndex = 4;

        buyPanel.gameObject.SetActive(true);
    }
    public void OpenBuyMenu6()
    {
        priceGold = priceList[5];
        skinCheckIndex = 5;

        buyPanel.gameObject.SetActive(true);

    }
    public void OpenBuyMenu7()
    {
        priceGold = priceList[6];
        skinCheckIndex = 6;

        buyPanel.gameObject.SetActive(true);
    }
    public void OpenBuyMenu8()
    {
        priceGold = priceList[7];
        skinCheckIndex = 7;

        buyPanel.gameObject.SetActive(true);
    }
    public void OpenBuyMenu9()
    {
        priceGold = priceList[8];
        skinCheckIndex = 8;

        buyPanel.gameObject.SetActive(true);
    }

    public void closeBuyMenu()
    {
        buyPanel.gameObject.SetActive(false);
    }


    #endregion
    private void ButtonsUpdate()
    {
        for (int i = 0; i <= 8; i++)
        {
            if (buyCheck[i])
            {
                buttonsList[i].gameObject.SetActive(true);
                buyButtonsList[i].gameObject.SetActive(false);
            }
            else
            {
                buttonsList[i].gameObject.SetActive(false);
                buyButtonsList[i].gameObject.SetActive(true);
            }
        }
    }

    private void UpdatePlayerPrefs()
    {
        if (buyCheck[0])
        {
            PlayerPrefs.SetInt("character1", 1);
        }
        else if (!buyCheck[0])
        {
            PlayerPrefs.SetInt("character1", 0);
        }

        if (buyCheck[1])
        {
            PlayerPrefs.SetInt("character2", 1);
        }
        else if (!buyCheck[1])
        {
            PlayerPrefs.SetInt("character2", 0);
        }
        if (buyCheck[2])
        {
            PlayerPrefs.SetInt("character3", 1);
        }
        else if (!buyCheck[2])
        {
            PlayerPrefs.SetInt("character3", 0);
        }
        if (buyCheck[3])
        {
            PlayerPrefs.SetInt("character4", 1);
        }
        else if (!buyCheck[3])
        {
            PlayerPrefs.SetInt("character4", 0);
        }
        if (buyCheck[4])
        {
            PlayerPrefs.SetInt("character5", 1);
        }
        else if (!buyCheck[4])
        {
            PlayerPrefs.SetInt("character5", 0);
        }
        if (buyCheck[5])
        {
            PlayerPrefs.SetInt("character6", 1);
        }
        else if (!buyCheck[5])
        {
            PlayerPrefs.SetInt("character6", 0);
        }
        if (buyCheck[6])
        {
            PlayerPrefs.SetInt("character7", 1);
        }
        else if (!buyCheck[6])
        {
            PlayerPrefs.SetInt("character7", 0);
        }
        if (buyCheck[7])
        {
            PlayerPrefs.SetInt("character8", 1);
        }
        else if (!buyCheck[7])
        {
            PlayerPrefs.SetInt("character8", 0);
        }
        if (buyCheck[8])
        {
            PlayerPrefs.SetInt("character9", 1);
        }
        else if (!buyCheck[8])
        {
            PlayerPrefs.SetInt("character9", 0);
        }

    }

    private void StartingSettings()
    {
        if (PlayerPrefs.GetInt("character1") == 1)
        {
            buyCheck[0] = true;
        }
        if (PlayerPrefs.GetInt("character2") == 1)
        {
            buyCheck[1] = true;
        }
        if (PlayerPrefs.GetInt("character3") == 1)
        {
            buyCheck[2] = true;
        }
        if (PlayerPrefs.GetInt("character4") == 1)
        {
            buyCheck[3] = true;
        }
        if (PlayerPrefs.GetInt("character5") == 1)
        {
            buyCheck[4] = true;
        }
        if (PlayerPrefs.GetInt("character6") == 1)
        {
            buyCheck[5] = true;
        }
        if (PlayerPrefs.GetInt("character7") == 1)
        {
            buyCheck[6] = true;
        }
        if (PlayerPrefs.GetInt("character8") == 1)
        {
            buyCheck[7] = true;
        }
        if (PlayerPrefs.GetInt("character9") == 1)
        {
            buyCheck[8] = true;
        }
    }

    #region Buy Gold

    public void OpenBuyGoldMenu()
    {
        buyGoldPanel.gameObject.SetActive(true);
    }
    public void CloseBuyGoldMenu()
    {
        buyGoldPanel.gameObject.SetActive(false);
    }

    public void Buy500gold()
    {
        Debug.Log("gold aldim");
        gold += 500;
    }
    public void Buy2500gold()
    {
        gold += 2500;
    }
    public void Buy10000gold()
    {
        gold += 10000;
    }

    #endregion


}
