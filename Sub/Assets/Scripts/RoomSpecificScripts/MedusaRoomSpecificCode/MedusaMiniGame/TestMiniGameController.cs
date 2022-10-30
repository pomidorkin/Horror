using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMiniGameController : MonoBehaviour
{
    [SerializeField] GameObject miniGameObject;
    PlyerInputActions plyerInputActions;
    //[SerializeField] PlayerMovement playerMovement;
    [SerializeField] InputManager inputManager;
    [SerializeField] TestPlayer2D player2d;
    [SerializeField] GuardsActivator guardsActivator;

    private float timer = 0f;
    [SerializeField] private float timeToWin = 10f;
    //PlayerInput playerInput;
    private void Awake()
    {
        //playerMovement = playerMovement.GetPlayerInputActions();
        //playerMovement.ChangeInputActionMap(false, "MedusaMiniGame");
        plyerInputActions = inputManager.GetPlayerInputActions();
    }

    private void OnEnable()
    {
        //plyerInputActions.MedusaMiniGame.Up.performed += MoveUp;
        //plyerInputActions.MedusaMiniGame.Down.performed += MoveDown;
        inputManager.EnableInputActionMap(false, "MedusaMiniGame");
        timer = 0f;
    }

    private void OnDisable()
    {
        //plyerInputActions.MedusaMiniGame.Up.performed -= MoveUp;
        //plyerInputActions.MedusaMiniGame.Down.performed -= MoveDown;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToWin)
        {
            timer = 0f;
            MiniGameWin();
        }
    }

    public PlyerInputActions GetInputActions()
    {
        return plyerInputActions;
    }

    private void MoveDown(InputAction.CallbackContext obj)
    {
        Debug.Log("Move Down");
    }

    private void MoveUp(InputAction.CallbackContext obj)
    {
        Debug.Log("Move Up");
    }

    public void MiniGameLose()
    {
        CloseMiniGame();
    }

    public void MiniGameWin()
    {
        guardsActivator.ActivateMedusaLaser();
        CloseMiniGame();
    }

    private void CloseMiniGame()
    {
        player2d.SetPositionToDefault();
        inputManager.EnableInputActionMap(true, "MedusaMiniGame");
        miniGameObject.SetActive(false);
    }
}
