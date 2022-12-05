using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetkod : MonoBehaviour
{
    public int score;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        var hit = coll.gameObject;
        if(hit.tag == "Player" && Time.time > timer){
            PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+ score);
            var creator = GameObject.FindGameObjectWithTag("creator").GetComponent<planetcreator>();
            creator.planetcreate(transform.position);
            timer = Time.time + 0.4f;
            timer = Time.time + 100000000000f;
        }
    }
}
