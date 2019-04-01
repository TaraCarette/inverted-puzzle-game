using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wizardHatMovement : MonoBehaviour
{
    public float speed;
    public static bool resetTime = false;

    private Rigidbody2D rb2d;
    private string sceneName;
    private AudioSource source;
    private Vector3 originalPos;
    public static bool hit = false;


    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        sceneName = SceneManager.GetActiveScene().name;

        source = GetComponent<AudioSource>();

        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            hit = false;
        }

        if (DialogueManager.talking == false)
        {
            Movement();
        }

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
            //Debug.Log("walk up");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
            //.Log("walk down");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            // Debug.Log("walk right");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            // Debug.Log("walk left");
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
            hit = true;
            Debug.Log("hit spike");
            source.Play();
            resetTime = true;
            gameObject.transform.position = originalPos;
        }
    }
}