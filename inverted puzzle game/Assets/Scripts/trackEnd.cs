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

    private AudioSource source;
    private float clipLength;

    // Start is called before the first frame update
    void Start()
    {
        currentScene =  SceneManager.GetActiveScene().name;
        nextLevel = currentScene.Replace("a", "b");

        source = GetComponent<AudioSource>();
        clipLength = source.clip.length;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (wizardSucess && hatSucess) 
        {
            //switch to same structure scene but with obstacles
            Debug.Log("finished puzzle");
            source.Play();
            Invoke("sceneSwitch", clipLength);
        }
    }

    void sceneSwitch()
    {
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }
}