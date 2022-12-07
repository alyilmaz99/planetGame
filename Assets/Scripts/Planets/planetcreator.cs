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
    public int fireUP;
    public int fireDOWN;
    public Text[] scoretext;
    public GameObject player;
    public GameObject blackhole;
    public GameObject[] fireball;
    float firetimer;
    public float firetime;
    void Start()
    {
        PlayerPrefs.SetInt("score",0);
        firetimer = Time.time + firetime;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext[0].text = PlayerPrefs.GetInt("score").ToString();
        scoretext[1].text = PlayerPrefs.GetInt("score").ToString();
        if(Time.time > firetimer){
            firecreate();
        }
    }
    public void planetcreate(Vector3 position){
        int planetno = Random.Range(1, 10);
        int x = Random.Range(limitLEFT, limitRIGHT);
        float y = Random.Range(limitUP, limitDOWN);
        Instantiate(planet[planetno], new Vector2(position.x + x, position.y + y), Quaternion.identity);
        holecreate();
    }
    public void firecreate(){
        float y = Random.Range(fireDOWN, fireUP);
        int fired = Random.Range(0,2);
        firetimer = Time.time + firetime - (PlayerPrefs.GetInt("score")/100);
        if(fired == 0)
        Instantiate(fireball[0], new Vector2(player.transform.position.x - 14, player.transform.position.y + y), Quaternion.identity);
        else
        Instantiate(fireball[1], new Vector2(player.transform.position.x + 14, player.transform.position.y + y), Quaternion.identity);
    }
    public void holecreate(){
        int x = Random.Range(limitLEFT, limitRIGHT);
        float y = Random.Range(limitUP, limitDOWN);
        Instantiate(blackhole,  new Vector2(player.transform.position.x + x, player.transform.position.y + y), Quaternion.identity);
    }
}
