using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public int timeWaiting; // make it easier to adjust time

    public GameObject door;
    public GameObject doorSwitch;
    private BoxCollider2D switchCollider;

    private AudioSource source;
    private AudioSource doorSource;

    public bool hit;
    public bool triggered = false;
    public static bool darken;
    Renderer buttonRend;


    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        source = doorSwitch.GetComponent<AudioSource>();

        doorSource = door.GetComponent<AudioSource>();
        buttonRend = doorSwitch.GetComponent<Renderer>();
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
        door.SetActive(true);
        doorSwitch.GetComponent<CircleCollider2D>().enabled = true;
        hit = false;
        Debug.Log("IM HIT");

    }

    void reactivateDoor()
    {
        Debug.Log(door.activeSelf);
        //if already reactivated from death, do nothing
        if (door.activeSelf == false) 
        {
            door.SetActive(true);
            doorSwitch.GetComponent<CircleCollider2D>().enabled = true; 
            doorSource.Play();
            buttonRend.material.color = Color.white;

        }
        triggered = false;
    }


    public void TriggeredEnter(Collider2D other)
    {
        if (!triggered) 
        {
            //for if an obstacle is hit
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("playerHat"))
            {
                source.Play();
                
                doorSwitch.GetComponent<CircleCollider2D>().enabled = false;
                door.SetActive(false);
                buttonRend.material.color = Color.gray;

                Debug.Log("I'm here");
                triggered = true;

                Invoke("reactivateDoor", timeWaiting);
                
            }
            
        }

        
    }


}
