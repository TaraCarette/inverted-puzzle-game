using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
