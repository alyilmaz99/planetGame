using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getscore : MonoBehaviour
{
    public GameObject planet;
    public string ctag;
    public bool right;
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
        if(hit.tag == ctag){
            if(right = true){
               planet.GetComponent<planetkod>().getscorer();
            }
            else{
                planet.GetComponent<planetkod>().getscorel();
            }
        }
    }
}
