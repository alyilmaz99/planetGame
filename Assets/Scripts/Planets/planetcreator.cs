using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planetcreator : MonoBehaviour
{
    public GameObject[] planet;
    public int limitRIGHT;
    public int limitLEFT;
    public int limitUP;
    public int limitDOWN;
    public Text scoretext;
    void Start()
    {
        PlayerPrefs.SetInt("score",0);
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = PlayerPrefs.GetInt("score").ToString();
    }
    public void planetcreate(Vector3 position){
        int planetno = Random.Range(1, 10);
        int x = Random.Range(limitLEFT, limitRIGHT);
        float y = Random.Range(limitUP, limitDOWN);
        Instantiate(planet[planetno], new Vector2(position.x + x, position.y + y), Quaternion.identity);
    }
}
