using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        dialogueLines = new Queue<string>();    // Initializes the queue
    }

}
