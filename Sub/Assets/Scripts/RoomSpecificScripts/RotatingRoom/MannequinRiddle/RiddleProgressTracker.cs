using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleProgressTracker : MonoBehaviour
{
    private int progressCounter = 0;
    public bool allSolvedCorrectrly = true;

    public void RiddleStepSolved()
    {
        if (allSolvedCorrectrly)
        {
            allSolvedCorrectrly = false;
            progressCounter++;
            Debug.Log("progressCounter: " + progressCounter);
        }
    }
}
