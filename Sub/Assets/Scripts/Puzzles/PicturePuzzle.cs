using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] InputManager inputManager;
    [SerializeField] ImageScrollScript[] imageScrollElements;
    [SerializeField] PlayerMovement playerMovement;
    PlyerInputActions plyerInputActions;
    StageManager stageManager;
    //GameManagerScript gameManager;
    private int selectedElement = 0;

    private void Start()
    {
        playerComblination = new int[correctCombination.Length];
        stageManager = FindObjectOfType<StageManager>();
        ActivateElementSelection();
        //gameManager = FindObjectOfType<GameManagerScript>();
    }

    private void OnEnable()
    {
        plyerInputActions = playerMovement.GetPlayerInputActions();
        inputManager.EnableInputActionMap(false, "MythMinigame");
        puzzleManager.OnPuzzleInteractedAction += UpdateCombinations;
        plyerInputActions.MythMinigame.Left.performed += OnLeftHandler;
        plyerInputActions.MythMinigame.Right.performed += OnRightHandler;
        plyerInputActions.MythMinigame.Up.performed += OnUpHandler;
        plyerInputActions.MythMinigame.Down.performed += OnDownHandler;
        plyerInputActions.MythMinigame.Close.performed += OnCloseHandler;
    }

    private void OnDisable()
    {
        puzzleManager.OnPuzzleInteractedAction -= UpdateCombinations;
        plyerInputActions.MythMinigame.Left.performed -= OnLeftHandler;
        plyerInputActions.MythMinigame.Right.performed -= OnRightHandler;
        plyerInputActions.MythMinigame.Up.performed -= OnUpHandler;
        plyerInputActions.MythMinigame.Down.performed -= OnDownHandler;
        plyerInputActions.MythMinigame.Close.performed -= OnCloseHandler;
    }

    private void OnCloseHandler(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        ClosePuzzle();
    }

    private void OnDownHandler(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        imageScrollElements[selectedElement].ActivateNextImage(false);
    }

    private void OnUpHandler(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        imageScrollElements[selectedElement].ActivateNextImage(true);
    }

    private void OnLeftHandler(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (selectedElement > 0)
        {
            selectedElement--;
        }
        else
        {
            selectedElement = imageScrollElements.Length - 1;
        }

        ActivateElementSelection();
    }

    private void ActivateElementSelection()
    {
        foreach (ImageScrollScript imageScroll in imageScrollElements)
        {
            imageScroll.MakeSelectionActive(false);
        }
        imageScrollElements[selectedElement].MakeSelectionActive(true);
    }

    private void OnRightHandler(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (selectedElement >= imageScrollElements.Length - 1)
        {
            selectedElement = 0;
        }
        else
        {
            selectedElement++;
        }
        ActivateElementSelection();
    }

    private void UpdateCombinations(object source, PuzzleManager.PuzzleInteractedEventArgs args)
    {
        playerComblination[args.MyID] = args.CombinationNumber;
        storyTexts[args.MyID].text = args.StoryText;
    }

    public void ClosePuzzle()
    {
        CompareCombination();
        inputManager.EnableInputActionMap(true, "MythMinigame");
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
