using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleManager : MonoBehaviour
{
    public class PuzzleInteractedEventArgs : EventArgs
    {
        public int MyID { get; set; }
        public int CombinationNumber { get; set; }
        public string StoryText { get; set; }
    }

    public delegate void PuzzleInteractedAction(object source, PuzzleInteractedEventArgs args);
    public event PuzzleInteractedAction OnPuzzleInteractedAction;

    public void PuzzleInteracted(int myID, int combinationNumber, string storyText)
    {
        Debug.Log(myID + " " + combinationNumber);
        OnPuzzleInteractedAction(this, new PuzzleInteractedEventArgs {MyID = myID , CombinationNumber = combinationNumber, StoryText = storyText });
    }
}
