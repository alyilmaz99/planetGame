using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private bool flyCheck = false;

    [SerializeField] private float forcePower, forcePower2;
    [SerializeField] private Vector2 rotationVector2 = new Vector2(0, 1);

    [SerializeField] private float timer;
    private float timerfixer;
    [SerializeField] private bool timerBool = true;

    public bool endCheck = false;

    [SerializeField] private GameObject parentObject;
    public int scoreadder;
    float speed;

    [SerializeField] private GameObject childObject;
    public int planetCount;
    

        [Header("Sound Settings")]
    [SerializeField] private GameSceneSettings gameSceneSettings;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip experimentSong;

    [Header("Reborn Settings")]
    [SerializeField] private GameObject rebornObject;
    [SerializeField] private Vector3 rebornTransform;
    [SerializeField] private Transform rebornRotation;

    [Header("Sprite Settings")]
    [SerializeField] private List<Sprite> SpriteList = new List<Sprite>();
    [SerializeField] private int spriteCheck;


    void Start()
    {

        if (PlayerPrefs.HasKey("Character"))
        {
            spriteCheck = PlayerPrefs.GetInt("Character");
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteList[spriteCheck -1];
        }


        planetCount = 0;

        

        PlayerPrefs.SetInt("score",0);
        timerfixer = timer;
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1;
    }

    
    void Update()
    {
        Movement();
        EndGame();

        if (planetCount > 5)
        {
            forcePower = forcePower2;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            ////first movement system
            //flyCheck = false;
            //timerBool = true;
            //timer = timerfixer;
            //Debug.Log("Planet enter");

            //transform.parent = other.gameObject.transform;

            //transform.rotation = Quaternion.Euler(0, 0, 180f);

            ////rebornSettings

            //rebornTransform = (transform.position);
            //rebornObject = other.gameObject;




            //other movement system
            flyCheck = false;
            timerBool = true;
            timer = timerfixer;
            //Debug.Log("Planet enter");



            transform.rotation = Quaternion.Euler(0, 0, 180f);

            childObject.transform.parent = null;
            transform.parent = null;
            transform.parent = childObject.transform;


            transform.parent = childObject.gameObject.transform;
            //transform.parent = other.gameObject.transform;

            //angle
            Vector3 norTar = (other.gameObject.transform.position - childObject.transform.position).normalized;
            float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, 0, angle - 90);
            childObject.transform.rotation = rotation;
            //angle finished

            childObject.transform.Rotate(0, 0, 180, Space.Self);


            transform.parent = null;

            childObject.transform.parent = gameObject.transform;

            float distance = Vector3.Distance(other.gameObject.transform.position, transform.position);
            //Debug.Log(distance);

            if (distance > 5.2f)
            {
                //float off = distance - 5.2f;
                transform.localPosition += new Vector3(0, -0f, 0);
            }

            transform.parent = other.gameObject.transform;

            ////rebornSettings

            rebornTransform = (transform.position);
            rebornObject = other.gameObject;



            Vibration();
            Sound();
            planetCount++;
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
            //Debug.Log("Planet exit");

           Destroy(other.gameObject, 60f);
           timerBool = false;
       }

        if (other.gameObject.tag == "First Planet")
        {
            //Debug.Log("First Planet exit");

            Destroy(other.gameObject, 60f);
            timerBool = false;
        }
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sound();
            Vibration();
            //transform.parent = null;
            flyCheck = true;
        }
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
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
        
        if (PlayerPrefs.GetInt("vib") == 1)
        {
            Handheld.Vibrate();
           
        }
        else if (PlayerPrefs.GetInt("vib") == 0)
        {
           
        }

    }
    void Sound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audioSource.PlayOneShot(experimentSong);
        }
        
    }
    public void Reborn()
    {
        transform.position = rebornTransform;
        transform.parent = rebornObject.transform;
        timer = timerfixer;
    }

}
