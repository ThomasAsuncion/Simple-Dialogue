using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;                   // Drag and drop the NameText object under the DialogueBox object into this respective field slot in the Inspector
    public Text dialogueText;               // Drag and drop the DialogueText object under the DialogueBox object into this respective field slot in the Inspector
    public Animator animator;               // Drag and drop the DialogueBox object into this field slot in the Inspector
    public float dialogueWaitTime;
    public bool dialogueReadingActive;
    private Queue<string> dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        dialogueLines = new Queue<string>();    // Initializes the queue
    }


    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isActive", true);
        nameText.text = dialogue.name;  // Setups the actual name to appear on the UI with the name in the dialogue
        dialogueLines.Clear();          // Clears out all of the initial or placeholder text

        // Loads up each dialogue line that was passed from the inspector to the dialogue object in the dialogueLines queue
        foreach(string dialogueLine in dialogue.lines)
        {
            dialogueLines.Enqueue(dialogueLine);
        }
        
        // Prints the line after all the dialogue has been queued up and ready to go
        PrintNextLine();

    }

    public void PrintNextLine()
    {
        // Conditional prevents the game from proceeding the dialogue without it being complete
        if (dialogueReadingActive == false)
        {
            // When the queue has reached 0 (meaning there's no more dialogue left) end the dialogue sequence, otherwise dequeue the current line and store it in a string
            if (dialogueLines.Count == 0)
            {
                EndDialogue();
                return;
            }
            else
            {
                string dialogueLine = dialogueLines.Dequeue();
                StopAllCoroutines(); // Prevents the game from running 2 dialogue lines at once if the user proceeds without the current dialogue line finishing (prevents TypewriteLine() from running in parallel)
                StartCoroutine(TypewriteLine(dialogueLine)); // Calls the IEnumerator method to actually run
            }
        }
    }

    // Coroutine - must be invoked by StartCoroutine
    IEnumerator TypewriteLine (string dialogueLine)
    {
        dialogueReadingActive = true;   // Dialogue is currently reading, prevent proceeding
        dialogueText.text = "";         // Intialize the UI dialogue text value to an empty string (since this will typewrite each char one by one)

        // Converts the dialogue line string to an array of each individual char and takes each separate letter appends it to the dialogue
        foreach (char currentLetter in dialogueLine.ToCharArray())
        {
            dialogueText.text += currentLetter;
            yield return new WaitForSeconds(dialogueWaitTime * Time.deltaTime); ; // Waits an amount of time before typing each letter out
        }
        dialogueReadingActive = false;  // Dialogue is no longer reading, allow proceeding
    }

    void EndDialogue()
    {
        animator.SetBool("isActive", false);
        Debug.Log("End of conversation");
    }
}
