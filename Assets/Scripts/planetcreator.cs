using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetcreator : MonoBehaviour
{
    public GameObject[] planet;
    public int limitRIGHT;
    public int limitLEFT;
    public int limitUP;
    public int limitDOWN;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void planetcreate(){
        int planetno = Random.Range(1, 11);
        int x = Random.Range(limitLEFT, limitLEFT);
        int y = Random.Range(limitUP, limitDOWN);
        Instantiate(planet[0], new Vector2(x, y), Quaternion.identity);
    }
}
