using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorStageOne : MonoBehaviour
{
    [SerializeField] AllDoorController allDoorController;
    [SerializeField] GameObject corridorStageObject;
    [SerializeField] Transform playerTransform;
    [SerializeField] StageManager stageManager;
    [SerializeField] int requiredDoorInteractionNumber;
    private int currentDoorInteractionNumber = 0;
    private float timer = 0f;
    private float goalUpdateSpeed = 1f;
    private Vector3 initialPlayerPosition;
    private void OnEnable()
    {
        corridorStageObject.gameObject.SetActive(true);
        initialPlayerPosition = playerTransform.position;
    }

    private void Start()
    {
        allDoorController.MakeAllDoorsInteractable(false);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= goalUpdateSpeed)
        {
            Debug.Log(Vector3.Distance(initialPlayerPosition, playerTransform.position));
            timer = 0;
            stageManager.currentStage.stageGoal.SetCurrentAmount(Vector3.Distance(initialPlayerPosition, playerTransform.position));
        }
        // And enough doors were interacted
        
    }


}
