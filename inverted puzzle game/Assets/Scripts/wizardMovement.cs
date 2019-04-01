using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wizardMovement : MonoBehaviour
{
    public float speed;

    private GameObject hat;
    private Rigidbody2D rb2d;
    private string sceneName;
    private AudioSource source;
    private Vector3 originalPos;
    private Vector3 hatOriginalPos;
    public static bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        sceneName = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;

        source = GetComponent<AudioSource>();

        hat = GameObject.FindGameObjectsWithTag("playerHat")[0];

        originalPos = gameObject.transform.position;
        hatOriginalPos = hat.transform.position;
    }


    // Update is called once per frame
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
        //for if an obstacle is hit
        if (other.gameObject.CompareTag("Spike"))
        {
            hit = true;

            Debug.Log("hit spike");
            source.Play();
            gameObject.transform.position = originalPos;
            hat.transform.position = hatOriginalPos;
        }

        //for reaching the spots needed
        if (other.gameObject.CompareTag("WizardEnd"))
        {
            Debug.Log("wizard got here!");
            trackEnd.wizardSucess = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WizardEnd"))
        {
            Debug.Log("wizard left");
            trackEnd.wizardSucess = false;
        }
    }

    // void sceneSwitch()
    // {
    //     SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    // }
}