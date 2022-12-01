using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Distance Settings")]
    public GameObject mainCharacter;
    Vector3 offset;


    [Header("Alternative Settings")]
    [SerializeField] private GameObject focusingObject;
    private Transform target;
    public float camSpeed;

    [SerializeField] private float cameraHeight;
    [SerializeField] private PlayerControl playerControl;


    void Start()
    {

        offset = transform.position - mainCharacter.transform.position;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        // transform.position = mainCharacter.transform.position + offset;
        objectFocus();
    }

    // alternative focus
    void objectFocus()
    {
        focusingObject = playerControl.gameObject.transform.parent.gameObject;
        target = focusingObject.transform;
        //transform.position = focusingObject.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y+ cameraHeight, target.position.z-10f), camSpeed*Time.deltaTime);
    }

}
