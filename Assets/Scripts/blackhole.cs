using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour
{
    public float destroytime;
    void Start()
    {
        Invoke("destroy",destroytime);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            player.endCheck = true;
        }
    }
    void destroy(){
        Destroy(gameObject);
    }
}
