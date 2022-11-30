using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Distance Settings")]
    public GameObject mainCharacter;
    Vector3 offset;

    void Start()
    {

        offset = transform.position - mainCharacter.transform.position;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        transform.position = mainCharacter.transform.position + offset;
    }
}
