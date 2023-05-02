using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Invoke("destroy",5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed*Time.deltaTime,0,0);
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
