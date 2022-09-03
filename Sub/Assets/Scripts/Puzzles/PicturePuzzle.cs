using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;
using TMPro;

public class PicturePuzzle : MonoBehaviour
{
    [SerializeField] int[] correctCombination;
    [SerializeField] Animator animator;
    int[] playerComblination;
    [SerializeField] PuzzleManager puzzleManager;
    [SerializeField] TMP_Text[] storyTexts;
    [SerializeField] MakeActiveInteractable picture;
    [SerializeField] GameObject plushBear;
    StageManager stageManager;

    private void Start()
    {
        playerComblination = new int[correctCombination.Length];
        stageManager = FindObjectOfType<StageManager>();
    }

    private void OnEnable()
    {
        puzzleManager.OnPuzzleInteractedAction += UpdateCombinations;
    }

    private void OnDisable()
    {
        puzzleManager.OnPuzzleInteractedAction -= UpdateCombinations;
    }

    private void UpdateCombinations(object source, PuzzleManager.PuzzleInteractedEventArgs args)
    {
        playerComblination[args.MyID] = args.CombinationNumber;
        storyTexts[args.MyID].text = args.StoryText;
    }

    public void ClosePuzzle()
    {
        CompareCombination();
        gameObject.SetActive(false);
    }

    private void CompareCombination()
    {
        if (Enumerable.SequenceEqual(playerComblination, correctCombination))
        {
            // TODO: Make it so that it reaches the goal only when the puzzle is closed
            stageManager.currentStage.stageGoal.MarkAsInteracted();
            animator.Play("ChestOpenAnimation");
            picture.MakeUninteractable();
            plushBear.SetActive(true);
            Debug.Log("Combination is correct");
        }
    }
}
