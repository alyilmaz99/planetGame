using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Market : MonoBehaviour
{
    [SerializeField] private int skinCheck;
    private void Start()
    {
        skinCheck = PlayerPrefs.GetInt("Character");
    }

    private void Update()
    {
        skinCheck = PlayerPrefs.GetInt("Character");
    }

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

    public void InAppCharacter1()
    {
        Debug.Log("satin alindiiii");
    }

}
