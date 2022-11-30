using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private bool flyCheck = false;

    [SerializeField] private float forcePower;
    [SerializeField] private Vector2 rotationVector2 = new Vector2(0, 1);

    [SerializeField] private float timer;
    private float timerfixer;
    [SerializeField] private bool timerBool = true;


    [SerializeField] private GameObject parentObject;
    
    void Start()
    {
        timerfixer = timer;
    }

    
    void Update()
    {
        Movement();
        EndGame();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            flyCheck = false;
            timerBool = true;
            timer = timerfixer;
            Debug.Log("Planet enter");
            transform.parent = other.gameObject.transform;
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "First Planet")
        {
            timer = timerfixer;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            Debug.Log("Planeeeeet exiiitt");

            Destroy(other.gameObject, 4f);
            timerBool = false;
        }
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.parent = null;
            flyCheck = true;
        }
        if (flyCheck)
        {
            transform.Translate(rotationVector2 * forcePower * Time.deltaTime);
        }
    }

    void EndGame()
    {
        if (!timerBool)
        {
            timer -= Time.deltaTime;
        }


        if (timer < 0)
        {
            Debug.Log("Game ended");
        }
    }


}
