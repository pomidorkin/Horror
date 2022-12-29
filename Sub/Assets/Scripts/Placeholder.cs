using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    [SerializeField] StageManager stageManager;
    [SerializeField] GameObject[] palceholders;

    private void OnEnable()
    {
        stageManager.OnStageChangedAction += StangeChangedHalndler;
    }

    private void StangeChangedHalndler(object source, StageManager.StangeChangedActionEventArgs args)
    {
        if (stageManager.currentStage.stageLocationType == Stage.StageLocationType.corridor)
        {
            foreach (GameObject placeholder in palceholders)
            {
                placeholder.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject placeholder in palceholders)
            {
                placeholder.gameObject.SetActive(false);
            }
        }
    }
}
