using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour
{
    public float destroytime;
    Vector3 scaleChange;
    public float growspeed;
    void Start()
    {
        Invoke("destroy",destroytime);
        scaleChange = new Vector3(0.01f * growspeed, 0.01f * growspeed, 0.01f * growspeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += scaleChange*Time.deltaTime;
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
