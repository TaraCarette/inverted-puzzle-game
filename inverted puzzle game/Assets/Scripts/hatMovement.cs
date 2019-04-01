using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hatMovement : MonoBehaviour
{
    public float speed;

    private GameObject wizard;
    private Rigidbody2D rb2d;
    private string sceneName;
    private AudioSource source;
    private Vector3 originalPos;
    private Vector3 wizardOriginalPos;

    public static bool hit = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sceneName = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;

        source = GetComponent<AudioSource>();

        wizard = GameObject.FindGameObjectsWithTag("Player")[0];

        originalPos = gameObject.transform.position;
        wizardOriginalPos = wizard.transform.position;
    }

    void Update()
    {
        if (hit == true)
        {
            hit = false;
        }

        if (DialogueManager.talking == false && trackEnd.startToPlay == false)
        {
            Movement();
        }

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //for if an obstacle is hit
        if (other.gameObject.CompareTag("Spike"))
        {
            hit = true;
            Debug.Log("hit spike");
            source.Play();
            gameObject.transform.position = originalPos;
            wizard.transform.position = wizardOriginalPos;
        }

        //for when thing gets to thing
        if (other.gameObject.CompareTag("HatEnd"))
        {
            Debug.Log("hat got here!");
            trackEnd.hatSucess = true;


        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HatEnd"))
        {
            Debug.Log("hat left");
            trackEnd.hatSucess = false;
        }
    }
}