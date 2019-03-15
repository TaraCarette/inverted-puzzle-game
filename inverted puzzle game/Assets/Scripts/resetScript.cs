using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetScript : MonoBehaviour

{
    public static bool isPause = false;
    public GameObject askResetUI;
    private string curScene;
    private string preScene;


    void Start()
    {
        askResetUI.SetActive(false);
        curScene = SceneManager.GetActiveScene().name;
        preScene = curScene.Replace("b", "a");
    }


    // Update is called once per frame
    void Update()
    {
        if (isPause == false)
        {
            resume();
        }

        else
        {
            pause();
        }

        
    }

    public void resume()
    {
        askResetUI.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;

    }

    public void pause()
    {
        askResetUI.SetActive(true);
        isPause = true;
        Time.timeScale = 0f;
        Debug.Log("paused");
    }

    public void resetLevel()
    {
        trackEnd.wizardSucess = false;
        trackEnd.hatSucess = false;
        Time.timeScale = 1f;
        isPause = false;
        SceneManager.LoadScene(preScene, LoadSceneMode.Single);

    }



}
