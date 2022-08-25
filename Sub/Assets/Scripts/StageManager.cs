using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int currentStageId = 0;
    [SerializeField] Stage[] stages;
    //[SerializeField] Progress progress;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] TMP_Text questText;
    public Stage currentStage;

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
            /*while (stages[gameManager.savedStageId] != currentStage)
            {
                currentStageId++;
                Debug.Log("currentStageId: " + currentStageId);
            }*/
            currentStageId = gameManager.saveManager.State.currentStage;

            // Saving_Test
            //currentStage = gameManager.savedStage;
            currentStage = stages[gameManager.saveManager.State.currentStage];
            InvokeStageCheck(/*gameManager.savedStage*/stages[gameManager.savedStageId]);
        }
        else
        {
            // TODO: Implement saving here
            // Saving_Test
            currentStage = stages[currentStageId];
            //currentStage = stages[gameManager.saveManager.State.currentStage];
            /*if (!progress.currentStage)
            {
                progress.currentStage = currentStage;
            }*/

            if (stages[gameManager.saveManager.State.currentStage] != currentStage)
            {
                UpdateAndSaveStage();
            }
        }

        SetQuestText();
    }

    private void UpdateAndSaveStage()
    {
        gameManager.saveManager.State.currentStage = currentStageId;
        gameManager.saveManager.Save();
    }

    private void GoToNextStage()
    {
        // TODO: Update saving file here
        currentStageId++;
        currentStage = stages[currentStageId];
        //progress.currentStage = currentStage;
        UpdateAndSaveStage(); // Test
        OnStageChangedAction(this, new StangeChangedActionEventArgs() { CurrentStage = currentStage });
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
