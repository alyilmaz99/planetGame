using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanets : MonoBehaviour
{


    [SerializeField] private float rotationSpeed;
    private Vector3 rotationVector = new Vector3(0, 0, 1);
    int speed;

    void Start()
    {
    }
    void Update()
    {
        if(speed < 2){
            speed = 1 +(PlayerPrefs.GetInt("score")/500);
        }
        speed = 1 +(PlayerPrefs.GetInt("score")/500);
        transform.Rotate(rotationVector * speed *rotationSpeed * Time.deltaTime);
    }
}
