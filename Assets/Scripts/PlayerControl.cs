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
    public int scoreadder;
    float speed;

    [SerializeField] private GameObject childObject;

    [Header("Sound Settings")]

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip experimentSong;

    [Header("Reborn Settings")]
    [SerializeField] private GameObject rebornObject;
    [SerializeField] private Vector3 rebornTransform;
    [SerializeField] private Transform rebornRotation;



    void Start()
    {
        PlayerPrefs.SetInt("score",0);
        timerfixer = timer;
        audioSource = GetComponent<AudioSource>();
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

            //rebornSettings

            rebornTransform = (transform.position);
            rebornObject = other.gameObject;




            Vibration();
            Sound();

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

           Destroy(other.gameObject, 60f);
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
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                transform.parent = null;
                flyCheck = true;
            }
        }
        if (flyCheck)
        {
            if(speed < 2){
            speed = 1 +(PlayerPrefs.GetInt("score")/500);
            }
            transform.Translate(rotationVector2 * forcePower * speed * Time.deltaTime);
        }
        
    }

    public void EndGame()
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
            Debug.Log("titriyoruz");
        }
        else if (PlayerPrefs.GetInt("vibrationPref") == 0)
        {
            Debug.Log("titremiyoruz");
        }

    }
    void Sound()
    {
        if (PlayerPrefs.GetInt("soundPref") == 1)
        {
            // music code
            audioSource.PlayOneShot(experimentSong);
            Debug.Log("muzik dinliyoruz");
        }
        else if (PlayerPrefs.GetInt("soundPref") == 0)
        {
            // music code
            Debug.Log("muzik dinlemiyoruz");
        }
    }
    public void Reborn()
    {
        transform.position = rebornTransform;
        transform.parent = rebornObject.transform;
        timer = timerfixer;
    }

}
