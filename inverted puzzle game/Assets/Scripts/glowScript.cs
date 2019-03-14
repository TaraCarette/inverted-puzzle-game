using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowScript : MonoBehaviour
{
    Renderer rend;
    Color col;
    float intCol;
    bool maxReached = false;
    string parentTag;
    bool collide = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        parentTag = this.transform.parent.tag;
        col = rend.material.color;
        intCol = 0f;
        col.a = intCol;
        rend.material.color = col;

    }

    // Update is called once per frame
    void Update()
    {
        if (intCol > 1f)
        {
            maxReached = true;
            Debug.Log("wiz in");
        }

        if (intCol < 0f)
        {
            maxReached = false;
            Debug.Log("wiz out");
        }

        if (collide == true)
        {
            changeCol();

        }
  

    }

    void changeCol()
    {
        if (maxReached == false)
        {
            intCol = intCol + 0.01f;
            Debug.Log("glow up");
        }

        if (maxReached == true)
        {
            intCol = intCol - 0.02f;
            Debug.Log("glow down");
        }
        col.a = intCol;
        rend.material.color = col;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //for if the tile is hit
        if ((other.gameObject.CompareTag("Player") && parentTag == "WizardEnd") || (other.gameObject.CompareTag("playerHat") && parentTag == "HatEnd"))
        {
            collide = true;
           
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player") && parentTag == "WizardEnd") || (other.gameObject.CompareTag("playerHat") && parentTag == "HatEnd"))
        {
            collide = false;
            intCol = 0f;
            col.a = intCol;
            rend.material.color = col;

        }
    }
}
