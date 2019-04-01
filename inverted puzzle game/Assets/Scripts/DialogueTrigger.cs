using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject triggerButton;

    public void TriggerDialogue()
   {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "playerHat")
        {
            
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            triggerButton.SetActive(false);
        }
    }

}
