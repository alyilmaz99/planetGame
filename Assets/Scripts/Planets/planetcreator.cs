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
    public List<GameObject> fireball;
    float firetimer;
    public float firetimeu;
    public float firetimed;
    float firey;
    int fired;
    float holey;
    int holex;
    float y;
    Vector3 ps;
    int fireb;
    float firetime;
    int planetno;
    void Start()
    {
        PlayerPrefs.SetInt("score",0);
        PlayerPrefs.SetInt("planetno",0);
        firetimer = Time.time + firetime;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext[0].text = PlayerPrefs.GetInt("score").ToString();
        scoretext[1].text = PlayerPrefs.GetInt("score").ToString();
        if(Time.time > firetimer && fireb == 1){
            firecreate();
        }
    }
    public void planetcreate(Vector3 position){
        ps = position;
        int rastgeleSayi = Random.Range(1, 11);
        if (planetno != rastgeleSayi){
            planetno = rastgeleSayi;

        }
        else if(planetno == rastgeleSayi){
            if(planetno < 10)
            planetno = planetno + 1;
            else
            planetno = planetno - 1;
        
        }
        int x = Random.Range(limitLEFT, limitRIGHT);
        y = Random.Range(limitUP, limitDOWN);
        Instantiate(planet[planetno], new Vector2(position.x + x, position.y + y), Quaternion.identity);
        firey = Random.Range(5, 12);
        fired = Random.Range(0,fireball.Count + 1);
        holey = Random.Range(fireDOWN + 10, y - 5);
        holex = Random.Range(1,3);
        if(holex == 1){
            Instantiate(blackhole,  new Vector2(position.x + x + 13, position.y + y + holey), Quaternion.identity);
        }
        else{
            Instantiate(blackhole,  new Vector2(position.x + x - 13, position.y + y + holey), Quaternion.identity);
        }
        firetimer = Time.time + 1f;
        fireb = Random.Range(1,3);
    }
    public void firecreate(){
        if(fired % 2 == 0)
        Instantiate(fireball[fired], new Vector2(player.transform.position.x - 14, ps.y + firey + 3), Quaternion.identity);
        else
        Instantiate(fireball[fired], new Vector2(player.transform.position.x + 14, ps.y + firey + 3), Quaternion.identity);
        firetime = Random.Range(firetimed,firetimeu);
        firetimer = Time.time + firetime - (PlayerPrefs.GetFloat("score")/250);
    }
    public void holecreate(){
        int x = Random.Range(limitLEFT, limitRIGHT);
        float y = Random.Range(limitUP, limitDOWN);
        Instantiate(blackhole,  new Vector2(player.transform.position.x + x, player.transform.position.y + y), Quaternion.identity);
    }
}
