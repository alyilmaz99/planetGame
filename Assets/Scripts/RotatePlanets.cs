using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanets : MonoBehaviour
{


    [SerializeField] private float rotationSpeed;
    private Vector3 rotationVector = new Vector3(0, 0, 1);

    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);
    }
}
