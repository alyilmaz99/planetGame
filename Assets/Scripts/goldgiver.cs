using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldgiver : MonoBehaviour
{
    int gold;
    public int scoreforgold;
    float timer;
    public Text goldtext;
    void Start()
    {
        
    }

    
    void Update()
    {
        gold = (int)(PlayerPrefs.GetInt("score")/scoreforgold);
        goldtext.text = gold.ToString();
    }
    public void goldgive(){
        if(Time.time > timer){
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + gold);
            Debug.Log(PlayerPrefs.GetInt("gold"));
            timer = Time.time + 1000000f;
            goldtext.text = gold.ToString();
        }

    }
}
