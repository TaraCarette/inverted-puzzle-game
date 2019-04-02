using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public int timeWaiting; // make it easier to adjust time
    // private int timePause;

    public GameObject door;
    public GameObject doorSwitch;
    private BoxCollider2D switchCollider;

    private AudioSource source;
    private AudioSource doorSource;

    public static bool hit;
    public bool triggered = false;


    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        source = GetComponent<AudioSource>();

        doorSource = door.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            gotHit();
            CancelInvoke();
            triggered = false;
        } 
 
    }

    void gotHit()
    {
        this.door.SetActive(true);
        this.doorSwitch.GetComponent<CircleCollider2D>().enabled = true;
        hit = false;
        Debug.Log("IM HIT");

    }

    void reactivateDoor()
    {
        Debug.Log(door.activeSelf);
        //if already reactivated from death, do nothing
        if (door.activeSelf == false) 
        {
            this.door.SetActive(true);
            this.doorSwitch.GetComponent<CircleCollider2D>().enabled = true; 
            doorSource.Play();

        }
        triggered = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered) 
        {
            //for if an obstacle is hit
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("playerHat"))
            {
                source.Play();
                
                this.doorSwitch.GetComponent<CircleCollider2D>().enabled = false;
                this.door.SetActive(false);

                Debug.Log("I'm here");
                triggered = true;

                Invoke("reactivateDoor", timeWaiting);
                
            }
            
        }

        
    }


}
