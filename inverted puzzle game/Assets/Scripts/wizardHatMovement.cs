using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wizardHatMovement : MonoBehaviour
{
    public float speed;
    public AudioClip hitObstacle;
    public static bool resetTime = false;

    private Rigidbody2D rb2d;
    private string sceneName;
    private AudioSource source;
    private Vector3 originalPos;
    // private GameObject timer;
    // private int startTime;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sceneName =  SceneManager.GetActiveScene().name;

        source = GetComponent<AudioSource>();
        source.clip = hitObstacle;

        // startTime = timer.beginTime;

        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("reached end");
            finishLevel.wizHat = true;

        }

        if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("hit spike");
            source.Play();
            resetTime = true;
            gameObject.transform.position = originalPos;
        }
    }
}
