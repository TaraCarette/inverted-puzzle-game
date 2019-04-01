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


    // Start is called before the first frame update
    void Start()
    {
        timePause = timeWaiting;
    }

    // Update is called once per frame
    void Update()
    {
        if(wizardHatMovement.hit == true || hatMovement.hit == true || wizardMovement.hit == true)
        {
            timePause = timeWaiting;
            door.SetActive(true);
            doorSwitch.GetComponent<CircleCollider2D>().enabled = true;

        }
        if (door.activeInHierarchy == false && timePause > 0)
        {
            timePause = timePause - 1;
            
            
        }

       if (timePause == 0)
       {
          door.SetActive(true);
          timePause = timeWaiting;
          doorSwitch.GetComponent<CircleCollider2D>().enabled = true;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //for if an obstacle is hit
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("playerHat"))
        {
            doorSwitch.GetComponent<CircleCollider2D>().enabled = false;
            door.SetActive(false);
            
        }

        
    }




}
