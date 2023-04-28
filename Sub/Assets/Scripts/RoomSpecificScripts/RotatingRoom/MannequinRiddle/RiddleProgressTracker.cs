using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleProgressTracker : MonoBehaviour
{
    [SerializeField] IndividualMannequin[] individualMannequins;
    [SerializeField] GameObject[] stages;
    private int progressCounter = 0;
    public bool allSolvedCorrectrly = true;

    public void RiddleStepSolved()
    {
        if (allSolvedCorrectrly)
        {
            allSolvedCorrectrly = false;
            progressCounter++;
            Debug.Log("progressCounter: " + progressCounter);
            foreach (IndividualMannequin individualMannequin in individualMannequins)
            {
                individualMannequin.SetInteractable(true);
            }
            switch (progressCounter)
            {
                case 1:
                    stages[progressCounter-1].SetActive(false);
                    stages[progressCounter].SetActive(true);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    // code block
                    break;
            }
        }
    }
}
