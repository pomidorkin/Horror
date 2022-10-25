using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMiniGameController : MonoBehaviour
{
    PlyerInputActions plyerInputActions;
    //[SerializeField] PlayerMovement playerMovement;
    [SerializeField] InputManager inputManager;
    //PlayerInput playerInput;
    private void Awake()
    {
        //playerMovement = playerMovement.GetPlayerInputActions();
        //playerMovement.ChangeInputActionMap(false, "MedusaMiniGame");
        plyerInputActions = inputManager.GetPlayerInputActions();
        inputManager.EnableInputActionMap(false, "MedusaMiniGame");
    }

    private void OnEnable()
    {
        plyerInputActions.MedusaMiniGame.Up.performed += MoveUp;
        plyerInputActions.MedusaMiniGame.Down.performed += MoveDown;
    }

    private void OnDisable()
    {
        plyerInputActions.MedusaMiniGame.Up.performed -= MoveUp;
        plyerInputActions.MedusaMiniGame.Down.performed -= MoveDown;
    }

    private void MoveDown(InputAction.CallbackContext obj)
    {
        Debug.Log("Move Down");
    }

    private void MoveUp(InputAction.CallbackContext obj)
    {
        Debug.Log("Move Up");
    }
}
