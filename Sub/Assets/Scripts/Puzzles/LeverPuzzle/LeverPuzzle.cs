using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeverPuzzle : MonoBehaviour
{

    [SerializeField] public Lever[] levers_1;
    [SerializeField] public Lever[] levers_2;
    public Lever[][] leversArray;
    [SerializeField] private GameObject door;
    [SerializeField] MovingCeiling movingCeiling;
    int nextLever;
    public bool[] solved;

    private void Awake()
    {
        leversArray = new Lever[2][];
        leversArray[0] = levers_1;
        leversArray[1] = levers_2;

        solved = new bool[2];
        solved[0] = false;
        solved[1] = false;
    }
    public void CheckCorrectLever(Lever lever, int leverPuzzleIndex)
    {
        Debug.Log("CheckCorrectLever");
        if (!solved[leverPuzzleIndex])
        {
            if (leversArray[leverPuzzleIndex][nextLever] == lever)
            {
                if (nextLever < (leversArray[leverPuzzleIndex].Length - 1))
                {
                    nextLever++;
                }
                else
                {
                    solved[leverPuzzleIndex] = true;
                    // Open dorr here
                    // Test below...
                    //FindObjectOfType<StageManager>().currentStage.stageGoal.MarkAsInteracted();
                    // Open door
                    switch (leverPuzzleIndex)
                    {
                        case 0:
                            door.gameObject.SetActive(false);
                            break;
                        case 1:
                            Debug.Log("secod sequence worked out");
                            movingCeiling.EnableMoving();
                            // Open door 2 and start moving the cealing
                            break;
                        default:
                            // code block
                            break;
                    }
                    nextLever = 0;



                }
                Debug.Log("Correct");
                Debug.Log("nextLever: " + nextLever + " levers.Length: " + leversArray[leverPuzzleIndex].Length);
            }
            else
            {
                nextLever = 0;
                CloseAllLevers(leverPuzzleIndex);
                Debug.Log("Incorrect");
            }
        }
    }

    public void CloseAllLevers(int leverPuzzleIndex)
    {
        foreach (Lever _lever in leversArray[leverPuzzleIndex])
        {
            if (_lever.turnedDown)
            {
                _lever.CloseLever();
            }
        }
    }

    public void ResetPuzzle()
    {
        nextLever = 0;
        for (int i = 0; i < leversArray.GetLength(0); i++)
        {
            solved[i] = false;
            CloseAllLevers(i);
        }
        // TODO: Reset doors
    }
}