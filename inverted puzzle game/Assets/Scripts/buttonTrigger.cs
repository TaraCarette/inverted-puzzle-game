using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTrigger : MonoBehaviour
{
    public SwitchAction myScript;

    void OnTriggerEnter2D(Collider2D other){
        myScript.TriggeredEnter(other);
    }
}
