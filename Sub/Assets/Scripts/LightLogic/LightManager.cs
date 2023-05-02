using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] float minLightValue = 0.2f;
    [SerializeField] float maxLightValue = 1f;
    [SerializeField] float duration = 3f;

    [SerializeField] StageManager stageManager;
    private Stage.StageLocationType previousStageType;
    private bool lightChangeTriggered = false;

    private float lightIntensity = 1f;

    private void OnEnable()
    {
        stageManager.OnStageChangedAction += StageChangedHandler;
    }

    private void OnDisable()
    {
        stageManager.OnStageChangedAction -= StageChangedHandler;
    }

    private void StageChangedHandler(object source, StageManager.StangeChangedActionEventArgs args)
    {
        if (args.CurrentStage.stageLocationType == Stage.StageLocationType.corridor)
        {
            if (previousStageType != null)
            {
                if (previousStageType != args.CurrentStage.stageLocationType)
                {
                    previousStageType = args.CurrentStage.stageLocationType;
                    MakeAmbientLightDark(true);
                }
            }
            else
            {
                previousStageType = args.CurrentStage.stageLocationType;
                MakeAmbientLightDark(true);
            }
            
        }
        else
        {
            if (previousStageType != null)
            {
                if (previousStageType != args.CurrentStage.stageLocationType)
                {
                    previousStageType = args.CurrentStage.stageLocationType;
                    MakeAmbientLightDark(false);
                }
            }
            else
            {
                previousStageType = args.CurrentStage.stageLocationType;
                MakeAmbientLightDark(false);
            }
        }
    }

    void Update()
    {
        if (lightChangeTriggered)
        {
            RenderSettings.ambientIntensity = lightIntensity;
        }
    }

    private IEnumerator ChangeLightIntensity(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            lightIntensity = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        lightIntensity = v_end;
        lightChangeTriggered = false;
    }

    public void MakeAmbientLightDark(bool val)
    {
        lightChangeTriggered = true;
        if (val)
        {
            StartCoroutine(ChangeLightIntensity(maxLightValue, minLightValue, duration));
        }
        else
        {
            StartCoroutine(ChangeLightIntensity(minLightValue, maxLightValue, duration));
        }
    }
}
