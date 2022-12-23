using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lastscorescript : MonoBehaviour
{
    public Text score;
    public float destroytime;
    void Start()
    {
        Invoke("destroy", destroytime);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = PlayerPrefs.GetInt("lastscore").ToString();
    }
    public void destroy(){
        Destroy(gameObject);
    }
}
