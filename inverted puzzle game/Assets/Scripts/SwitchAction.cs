using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public int timeWaiting; // make it easier to adjust time
    private int timePause;

    public GameObject door;
    public GameObject doorSwitch;
    private BoxCollider2D switchCollider;

    private AudioSource source;

    public static bool hit;


    // Start is called before the first frame update
    void Start()
    {
        timePause = timeWaiting;
        hit = false;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            this.timePause = 0;
        }

        if (this.timePause == 0)
        {
            this.Reset();

        }

        if ((this.door.activeInHierarchy == false) && (this.timePause > 0))
        {
            GoingDown();
            
        }

 
    }

    void Reset()
    {
        this.door.SetActive(true);
        this.timePause = timeWaiting;
        this.doorSwitch.GetComponent<CircleCollider2D>().enabled = true;

        if (hit == true)
        {
            hit = false;
            Debug.Log("IM HIT");
        }

    }

    void GoingDown()
    {
        this.timePause = timePause - 1;
        Debug.Log("GOING DOWN");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //for if an obstacle is hit
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("playerHat"))
        {
            source.Play();
            
            this.doorSwitch.GetComponent<CircleCollider2D>().enabled = false;
            this.door.SetActive(false);
            
        }

        
    }


}
