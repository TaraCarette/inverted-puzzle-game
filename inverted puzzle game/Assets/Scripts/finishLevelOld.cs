using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevelOld : MonoBehaviour
{
    public bool isPause = false;

    private string curScene;
    private string preScene;
    public GameObject deathUI;
    public GameObject victoryUI;
    public static bool wizHat = false;
    public static bool timeFail = false;

    // Start is called before the first frame update
    void Start()
    {
        deathUI.SetActive(false);
        victoryUI.SetActive(false);
        curScene = SceneManager.GetActiveScene().name;


    }

    // Update is called once per frame
    void Update()
    {


        if (wizHat == true)
        {
            isPause = true;
            pause();

        }

        if (timeFail == true)
        {
            //isPause = true;
            Time.timeScale = 0f;
            Debug.Log("ded");
            pause();

        }

    }

    public void pause()
    {
        if (timeFail == true)
            deathUI.SetActive(true);

        if (wizHat == true)
            victoryUI.SetActive(true);

        isPause = true;

        Time.timeScale = 0f;
        //Debug.Log("paused");
    }

    public void resetLevel()
    {
        Time.timeScale = 1f;
        deathUI.SetActive(false);
        timeFail = false;
        SceneManager.LoadScene(curScene, LoadSceneMode.Single);

    }

    public void nextLevel()
    {
        Time.timeScale = 1f;
        victoryUI.SetActive(false);
        wizHat = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
