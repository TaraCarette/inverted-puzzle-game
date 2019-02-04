using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trackEnd : MonoBehaviour
{
    public static bool wizardSucess = false;
    public static bool hatSucess = false;

    
    public GameObject wizardPlayer;
    public GameObject hatPlayer;
    
    // Update is called once per frame
    void Update()
    {
        if (wizardSucess && hatSucess) 
        {
            //switch to same structure scene but with obstacles
            Debug.Log("finished puzzle");
            SceneManager.LoadScene("level1b", LoadSceneMode.Single);
        }
    }
}
