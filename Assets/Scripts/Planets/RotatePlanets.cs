using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanets : MonoBehaviour
{


    [SerializeField] private float rotationSpeed;
    private Vector3 rotationVector = new Vector3(0, 0, 1);
    int speed;
    int direction;

    void Start()
    {
        PlayerPrefs.SetInt("planetno", PlayerPrefs.GetInt("planetno") + 1);
        if(PlayerPrefs.GetInt("planetno") > 9)
        direction = Random.Range(0,2);
    }
    void Update()
    {
        if(speed < 2){
            speed = 1 +(PlayerPrefs.GetInt("score")/500);
        }
        speed = 1 +(PlayerPrefs.GetInt("score")/500);
        if(direction == 0)
        transform.Rotate(rotationVector * speed *rotationSpeed * Time.deltaTime);
        if(direction == 1)
        transform.Rotate(rotationVector * -speed *rotationSpeed * Time.deltaTime);
    }
}
