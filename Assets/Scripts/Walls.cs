using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            player.endCheck = true;
        }
    }


}
