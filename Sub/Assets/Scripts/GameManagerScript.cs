using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] MouseLook mouseLook;
    [SerializeField] PlayerMovement playerMovement;
    public SaveManager saveManager;
    public int savedStageId;


    private void OnEnable()
    {
        saveManager = SaveManager.Instance;
        SaveManager.Instance.Load();
        if (!saveManager.State.firstStart)
        {
            savedStageId = saveManager.State.currentStage;
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

    public void DisablePlayerActions()
    {
        Cursor.lockState = CursorLockMode.None;
        mouseLook.DisableCameraMovement();
        playerMovement.DisablePlayerMovement();
    }

    public void EnablePlayerActions()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.EnableCameraMovement();
        playerMovement.EnablePlayerMovement();
    }
}
