using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int currentStageId = 0;
    [SerializeField] Stage[] stages;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] TMP_Text questText;
    public Stage currentStage;
    [SerializeField] AllDoorController allDoorController;

    public class StangeChangedActionEventArgs : EventArgs
    {
        public Stage CurrentStage { get; set; }
    }

    public delegate void StageChangedAction(object source, StangeChangedActionEventArgs args);
    public event StageChangedAction OnStageChangedAction;


    private void OnEnable()
    {
        StageGoal.OnActionChanged += GoToNextStage;
    }

    private void OnDisable()
    {
        StageGoal.OnActionChanged -= GoToNextStage;
    }
    private void Start()
    {
        if (!gameManager.saveManager.State.firstStart)
        {
            currentStageId = gameManager.saveManager.State.currentStage;

            // Saving_Test
            currentStage = stages[gameManager.saveManager.State.currentStage];
            InvokeStageCheck(stages[gameManager.savedStageId]);
        }
        else
        {
            // Saving
            currentStage = stages[currentStageId];
            if (stages[gameManager.saveManager.State.currentStage] != currentStage)
            {
                UpdateAndSaveStage();
            }
        }

        SetQuestText();
    }

    private void UpdateAndSaveStage()
    {
        gameManager.saveManager.State.firstStart = false;
        gameManager.saveManager.State.currentStage = currentStageId;
        gameManager.saveManager.Save();
    }

    private void GoToNextStage()
    {
        // TODO: Update saving file here
        currentStageId++;
        currentStage = stages[currentStageId];
        UpdateAndSaveStage();
        OnStageChangedAction(this, new StangeChangedActionEventArgs() { CurrentStage = currentStage });

        if (currentStage.stageLocationType == Stage.StageLocationType.room)
        {
            allDoorController.MakeAllDoorsInteractable(true);
        }
        Debug.Log("GoToNextStage();");

        SetQuestText();
    }

    public void InvokeStageCheck(Stage stage)
    {
        OnStageChangedAction(this, new StangeChangedActionEventArgs() { CurrentStage = stage });
        Debug.Log("InvokeStageCheck();");
    }

    private void SetQuestText()
    {
        questText.text = currentStage.questText;
    }

}
