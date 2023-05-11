using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
           var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            if (player.flyCheck==true)
            {
                player.endCheck = true;
            }
        
        }
    }


}
