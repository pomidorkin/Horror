using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    [SerializeField] Lever[] levers;
    int nextLever;
    public bool solved = false;

    public void CheckCorrectLever(Lever lever)
    {
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
                }
                Debug.Log("Correct");
                Debug.Log("nextLever: " + nextLever + " levers.Length: " + levers.Length);
            }
            else
            {
                // Deasctivate all levers
                nextLever = 0;
                Debug.Log("Incorrect");
            }
        }
    }
}
