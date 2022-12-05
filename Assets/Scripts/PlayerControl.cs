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
    public int scoreadder;
    float speed;





    void Start()
    {
        PlayerPrefs.SetInt("score",0);
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
            if(speed < 2){
            speed = 1 +(PlayerPrefs.GetInt("score")/500);
            }
            transform.Translate(rotationVector2 * forcePower * speed * Time.deltaTime);
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
