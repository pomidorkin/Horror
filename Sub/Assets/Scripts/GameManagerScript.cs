using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] MouseLook mouseLook;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    private bool isRespawningStage = false;
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

    public void SetRespawningStage(bool value)
    {
        isRespawningStage = value;
    }

    public bool GetIsRespawningStage()
    {
        return isRespawningStage;
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

    public void EnablePlayerActionsAndDisableVirtualCamera()
    {
        virtualCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.EnableCameraMovement();
        playerMovement.EnablePlayerMovement();
        // TODO: resetSpherePosition
    }
}
