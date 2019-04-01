using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevel : MonoBehaviour
{

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
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {


        if (wizHat == true)
        {
            pause();
            victoryUI.SetActive(true);
            
        }

        if(timeFail == true)
        {
            pause();
            deathUI.SetActive(true);
    
        }
        
    }

    public void pause()
    {
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
        trackEnd.wizardSucess = false;
        trackEnd.hatSucess = false;
        trackEnd.startToPlay = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
