using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleProgressTracker : MonoBehaviour
{
    [SerializeField] IndividualMannequin[] individualMannequins;
    [SerializeField] GameObject[] stages;
    private int progressCounter = 0;
    //public bool allSolvedCorrectrly = false;
    public int solvedCorrectly = 0;

    public void RiddleStepSolved()
    {
        if (/*allSolvedCorrectrly*/ solvedCorrectly >= 3)
        {
            //allSolvedCorrectrly = false;
            solvedCorrectly = 0;
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
                    stages[progressCounter - 1].SetActive(false);
                    stages[progressCounter].SetActive(true);
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
