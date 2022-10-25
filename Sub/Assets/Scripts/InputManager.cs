using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlyerInputActions plyerInputActions;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] PlayerActions playerActions;

    private void Start()
    {
        plyerInputActions = playerMovement.GetPlayerInputActions();
    }
    public void EnableInputActionMap(bool returnToDefault, string actionMapName)
    {
        playerMovement.ChangeInputActionMap(returnToDefault, actionMapName);
        mouseLook.EnableInputActions(returnToDefault);
        playerActions.EnableInputActions(returnToDefault);

    }

    public PlyerInputActions GetPlayerInputActions()
    {
        return plyerInputActions;
    }
}
