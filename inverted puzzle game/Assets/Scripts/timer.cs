using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour {

  public int timeLeft; //Seconds Overall
  public Text countdown; //UI Text Object
  public static int beginTime;

  private string currentScene;
  private AudioSource source;

  void Start () {
    StartCoroutine("LoseTime");
    Time.timeScale = 1; //Just making sure that the timeScale is right

    beginTime = timeLeft;

    source = GetComponent<AudioSource>();

    currentScene =  SceneManager.GetActiveScene().name;
  }

  void Update () {
            if (wizardHatMovement.resetTime == true)
            {
                timeLeft = beginTime;
                wizardHatMovement.resetTime = false;
            }
        
            countdown.text = ("Time Left:" + timeLeft);
        
     //Showing the Score on the Canvas
  }

  //Simple Coroutine
  IEnumerator LoseTime()
  {
    while (true) {
      yield return new WaitForSeconds (1);
      timeLeft--; 

      if (timeLeft <= 5) 
      {
          source.Play();
      }

      if (timeLeft <= 0) {
        Debug.Log("out of time");
        finishLevel.timeFail = true;
      }
    }
  }
}
