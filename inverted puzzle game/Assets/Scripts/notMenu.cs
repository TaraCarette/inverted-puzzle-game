using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notMenu : MonoBehaviour
{
    private AudioSource source;
    private bool pauseMenu;
    private bool victoryMenu;
    private bool deathMenu;
    private bool currentlyPaused = false;

    public GameObject pause;
    public GameObject victory;
    public GameObject death;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        source.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!currentlyPaused && (pause.activeSelf || victory.activeSelf || death.activeSelf)) 
        {
            Debug.Log("pause music");
            source.Pause();
            currentlyPaused = true;
        }

        if (currentlyPaused && !pause.activeSelf && !victory.activeSelf && !death.activeSelf) 
        {
            Debug.Log("unpaused music");
            source.Play();
            currentlyPaused = false;
        }
    }
}
