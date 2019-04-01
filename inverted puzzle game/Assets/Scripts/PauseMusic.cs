using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{
    private AudioSource source;
    private bool currentlyPaused = false;

    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentlyPaused && pause.activeSelf) 
        {
            Debug.Log("pause music");
            source.Pause();
            currentlyPaused = true;
        }

        if (currentlyPaused && !pause.activeSelf) 
        {
            Debug.Log("unpaused music");
            source.Play();
            currentlyPaused = false;
        }
    }

    public void stopMusic()
    {
        Debug.Log("Stop music");
        source.Pause();
    }
}
