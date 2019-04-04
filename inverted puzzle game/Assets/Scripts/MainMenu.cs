using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1a", LoadSceneMode.Single);
        //SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2a", LoadSceneMode.Single);
        //SceneManager.LoadScene(3);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("level3a", LoadSceneMode.Single);
        //SceneManager.LoadScene(5);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("level4a", LoadSceneMode.Single);
        //SceneManager.LoadScene(7);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("level5a", LoadSceneMode.Single);
        //SceneManager.LoadScene(9);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene("level6a", LoadSceneMode.Single);
        // SceneManager.LoadScene(11);
    }
}