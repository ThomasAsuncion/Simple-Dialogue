using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;   // Creates an object of type dialogue from the non-monobehaviour class created 

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);    // Finds the Object that has the DialogueManager script and invokes the StartDialoge method inside of it
    }
}
