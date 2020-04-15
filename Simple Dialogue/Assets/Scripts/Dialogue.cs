using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A class used to pass into the DialogeManager whenever a new dialogue is started
 *  No need for MonoBehaviour as this class does not need to sit on an object, however
 *  For a class like this (not derived from MonoBehaviour) to show up on the inspector it needs to be marked Serializable
 */
[System.Serializable]  
public class Dialogue
{
    public string name;     // NPC or Player Name that is currently talking
    
    [TextArea(3, 10)]       // Reformats the Text Box sizes in the Inspector so that it doesn't appear as one single line
    public string[] lines;  // The sentences/dialogue lines that will be loaded into the Queue



}
