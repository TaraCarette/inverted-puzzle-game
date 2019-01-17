using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackEnd : MonoBehaviour
{
    public static bool wizardSucess = false;
    public static bool hatSucess = false;

    private bool done = false;

    
    public GameObject wizardHatPlayer;
    public GameObject wizardPlayer;
    public GameObject hatPlayer;

    
    // Update is called once per frame
    void Update()
    {
        if (wizardSucess && hatSucess && !done) 
        {
            Debug.Log("Now!!!!!!!!!");
            Destroy(wizardPlayer);
            Destroy(hatPlayer);
            wizardHatPlayer.SetActive(true);
            done = true;
        }
    }
}
