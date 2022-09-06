using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeverPuzzle : MonoBehaviour
{

    [SerializeField] public Lever[] levers;
    int nextLever;
    public bool solved = false;

    public void CheckCorrectLever(Lever lever)
    {
        Debug.Log("CheckCorrectLever");
        if (!solved)
        {
            if (levers[nextLever] == lever)
            {
                if (nextLever < (levers.Length - 1))
                {
                    nextLever++;
                }
                else
                {
                    solved = true;
                    // Open dorr here
                    // Test below...
                    FindObjectOfType<StageManager>().currentStage.stageGoal.MarkAsInteracted();
                }
                Debug.Log("Correct");
                Debug.Log("nextLever: " + nextLever + " levers.Length: " + levers.Length);
            }
            else
            {
                nextLever = 0;
                CloseAllLevers();
                Debug.Log("Incorrect");
            }
        }
    }

    public void CloseAllLevers()
    {
        foreach (Lever _lever in levers)
        {
            if (_lever.turnedDown)
            {
                _lever.CloseLever();
            }
        }
    }
}