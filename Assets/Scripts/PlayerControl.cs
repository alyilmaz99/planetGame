using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private bool flyCheck = false;

    [SerializeField] private float forcePower;
    [SerializeField] private Vector2 rotationVector2 = new Vector2(0, 1);

    [SerializeField] private float timer;
    private float timerfixer;
    [SerializeField] private bool timerBool = true;

    public bool endCheck = false;

    

    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject childObject;





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

            
            
            transform.rotation = Quaternion.Euler(0,0,180f);
            //transform.rotation = childObject.transform.rotation;


            Vibration();

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
            endCheck = true;
            
        }
    }

    void Vibration()
    {
        if (PlayerPrefs.GetInt("vibrationPref") == 1)
        {
            Handheld.Vibrate();
        }

    }
    void Sound()
    {
        if (PlayerPrefs.GetInt("soundPref") == 1)
        {
            // music code
        }
    }

}
