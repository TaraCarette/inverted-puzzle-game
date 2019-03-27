using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour {

  public int timeLeft = 60; //Seconds Overall
  public Text countdown; //UI Text Object

  private string currentScene;

  void Start () {
    StartCoroutine("LoseTime");
    Time.timeScale = 1; //Just making sure that the timeScale is right

    currentScene =  SceneManager.GetActiveScene().name;
  }

  void Update () {
    countdown.text = ("Time Left:" + timeLeft); //Showing the Score on the Canvas
  }

  //Simple Coroutine
  IEnumerator LoseTime()
  {
    while (true) {
      yield return new WaitForSeconds (1);
      timeLeft--; 

      if (timeLeft <= 0) {
        Debug.Log("out of time");
        finishLevel.timeFail = true;
      }
    }
  }
}
