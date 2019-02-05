using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trackEnd : MonoBehaviour
{
    public static bool wizardSucess = false;
    public static bool hatSucess = false;

    private string currentScene;
    private string nextLevel;
    
    public GameObject wizardPlayer;
    public GameObject hatPlayer;

    // Start is called before the first frame update
    void Start()
    {
        currentScene =  SceneManager.GetActiveScene().name;
        nextLevel = currentScene.Replace("a", "b");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (wizardSucess && hatSucess) 
        {
            //switch to same structure scene but with obstacles
            Debug.Log("finished puzzle");
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }
}
