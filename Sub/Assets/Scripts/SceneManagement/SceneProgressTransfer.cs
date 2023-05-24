using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProgressTransfer : MonoBehaviour
{
    #region Instance
    // Singleton
    private static SceneProgressTransfer instance;
    public static SceneProgressTransfer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneProgressTransfer>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SceneProgressTransfer",
                        typeof(SceneProgressTransfer)).GetComponent<SceneProgressTransfer>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetGoalReached(StageManager stageManager)
    {
        Debug.Log("SceneManager.sceneLoaded");
        stageManager.currentStage.stageGoal.MarkAsInteracted();
        Destroy(this.gameObject);
    }
}