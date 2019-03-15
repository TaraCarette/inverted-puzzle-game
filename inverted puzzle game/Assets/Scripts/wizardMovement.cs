using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wizardMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sceneName = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;

    }

    // void FixedUpdate()
    // {
    //     float x = Input.GetAxisRaw("Horizontal");
    //     float z = Input.GetAxisRaw("Vertical");
    //     rb2d.position = z * transform.forward * Time.deltaTime * speed;
    //     rb2d.position = x * transform.right * Time.deltaTime * speed;
    // }

    // Update is called once per frame
    void Update()
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
            Debug.Log("hit spike");
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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
}
