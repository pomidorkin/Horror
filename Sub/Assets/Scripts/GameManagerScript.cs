using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //[SerializeField] Progress progress;
    public SaveManager saveManager;
    //public Stage savedStage;
    public int savedStageId;

    /*void Start()
    {
        saveManager = SaveManager.Instance;
        SaveManager.Instance.Load();
        if (!saveManager.State.firstStart)
        {
            savedStage = progress.currentStage;
        }

        ResumeGame();
    }*/

    private void OnEnable()
    {
        saveManager = SaveManager.Instance;
        SaveManager.Instance.Load();
        if (!saveManager.State.firstStart)
        {
            //savedStage = progress.currentStage; // Test
            savedStageId = saveManager.State.currentStage; // Test
        }

        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
