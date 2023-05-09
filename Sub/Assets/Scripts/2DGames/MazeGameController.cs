using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeGameController : MonoBehaviour
{
    PlyerInputActions plyerInputActions;
    [SerializeField] InputManager inputManager;
    [SerializeField] GameObject centerPoint;
    [SerializeField] GameObject[] levels;
    [SerializeField] GameObject jumpscarePicture;
    [SerializeField] GameObject cameraTimeline;
    [SerializeField] GameObject cameraResetter;
    int levelId = 0;
    private void OnEnable()
    {
        plyerInputActions = inputManager.GetPlayerInputActions();
        inputManager.EnableInputActionMap(false, "MazeMiniGame");
        centerPoint.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        centerPoint.gameObject.SetActive(true);
    }

    public PlyerInputActions GetPlayerInputActions()
    {
        return plyerInputActions;
    }

    public void MoveToNextLevel()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        levelId++;
        levels[levelId].SetActive(true);
        Debug.Log("Level Id: " + levelId);
    }

    public void ResetLevels()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        levelId = 0;
        levels[levelId].SetActive(true);
    }

    public void TurnOffAllLevels()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        levelId = 0;
    }

    public void PlayJumpScare()
    {
        jumpscarePicture.SetActive(true);
        StartCoroutine(DisableCoroutire());
    }

    private IEnumerator DisableCoroutire()
    {
        cameraTimeline.SetActive(false);
        yield return new WaitForSeconds(5);
        cameraResetter.SetActive(true);
        inputManager.EnableInputActionMap(true, "MazeMiniGame");
        gameObject.SetActive(false);
    }
}
