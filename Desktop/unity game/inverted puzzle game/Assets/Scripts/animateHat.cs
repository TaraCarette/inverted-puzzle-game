using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateHat : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vert();
        Horz();

    }


    /// <summary>
    /// input: none
    ///output: none
    /// this function changes the values of runVer depending on whether the up or down button is pressed
    /// when the up button is pressed, the value is negative and the run down animation will play
    /// when the down button is pressed, the value is positive and the run up animation will play.
    /// otherwise, the value is at 0 and the idle animation will play
    /// </summary>
    void Vert()
    {
        //for running up and down
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //anim.SetBool("run", true);
            anim.SetInteger("runVer", -1);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetInteger("runVer", 1);
        }


        else
        {
            //anim.SetBool("run", false);
            anim.SetInteger("runVer", 0);
        }
    }

    /// <summary>
    /// input: none
    ///output: none
    /// this function changes the values of runHor depending on whether the left or right button is pressed
    /// when the right button is pressed, the value is negative and the run down animation will play
    /// when the left button is pressed, the value is positive and the run up animation will play.
    /// otherwise, the value is at 0 and the idle animation will play
    /// </summary>
    void Horz()
    {
        //for running up and down
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //anim.SetBool("run", true);
            anim.SetInteger("runHor", 1);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetInteger("runHor", -1);
        }


        else
        {
            //anim.SetBool("run", false);
            anim.SetInteger("runHor", 0);
        }
    }

}
