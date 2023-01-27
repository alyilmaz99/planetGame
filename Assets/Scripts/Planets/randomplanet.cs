using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomplanet : MonoBehaviour
{
    int no;
    public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;
    void Start()
    {
        no = Random.Range(0,11);
        spriteRenderer.sprite = newSprite[no];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
