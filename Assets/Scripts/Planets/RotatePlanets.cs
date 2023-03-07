using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanets : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] private float rotationSpeed,rotationSpeed2;
    private Vector3 rotationVector = new Vector3(0, 0, 1);
    float speed;
    int direction;

    void Start()
    {

        player = GameObject.FindWithTag("Player");

        PlayerPrefs.SetInt("planetno", PlayerPrefs.GetInt("planetno") + 1);
        if(PlayerPrefs.GetInt("planetno") > 9)
        direction = Random.Range(0,2);
    }
    void Update()
    {
        if(speed < 1.5){
            speed = 1 +(PlayerPrefs.GetInt("score")/500);
        }
        speed = 1 +(PlayerPrefs.GetInt("score")/500);
        if(direction == 0)
        transform.Rotate(rotationVector * speed *rotationSpeed * Time.deltaTime);
        if(direction == 1)
        transform.Rotate(rotationVector * -speed *rotationSpeed * Time.deltaTime);

        SpeedUp();
    }

    void SpeedUp()
    {
        if (player.GetComponent<PlayerControl>().planetCount > 5)
        {
            rotationSpeed = rotationSpeed2;
        }
    }
}
