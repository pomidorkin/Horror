using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazePlayer : MonoBehaviour
{
    [SerializeField] MazeGameController mazeGameController;
    /// <Test>
    PlyerInputActions plyerInputActions;
    [SerializeField] InputManager inputManager;
    /// <EndTest>
    private Vector3 initialPosition;
    private bool initialPosSet = false;
    public float mouseSensitivity = 0.01f;
    private Vector2 MouseMoveInput;
    //private PlyerInputActions playerInputActions;
    Vector2 NonNormalizedDelta;

    private void OnEnable()
    {
        /*playerInputActions = mazeGameController.GetPlayerInputActions();
        mazeGameController.GetPlayerInputActions().MazeMiniGame.Movement.performed += Move2DPlayer;*/
        plyerInputActions = inputManager.GetPlayerInputActions();
        inputManager.EnableInputActionMap(false, "MazeMiniGame");
        plyerInputActions.MazeMiniGame.Movement.performed += Move2DPlayer;
        if (initialPosSet)
        {
            SetPositionToDefault();
        }
    }

    private void OnDisable()
    {
        plyerInputActions.MazeMiniGame.Movement.performed -= Move2DPlayer;
        SetPositionToDefault();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "2DCollision")
        {
            SetPositionToDefault();
            Debug.Log("Collision with the 2d collision tag");
            mazeGameController.ResetLevels();
        }
        if (collision.gameObject.tag == "2DFinish")
        {
            mazeGameController.MoveToNextLevel();
        }
        if (collision.gameObject.tag == "2DJumpscare")
        {
            mazeGameController.TurnOffAllLevels();
            mazeGameController.PlayJumpScare();
        }
    }

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        MouseMoveInput = plyerInputActions.MazeMiniGame.Movement.ReadValue<Vector2>();
    }

    void Move2DPlayer(InputAction.CallbackContext obj)
    {
        NonNormalizedDelta = MouseMoveInput * .5f * .1f;
        transform.localPosition = new Vector2(transform.localPosition.x + NonNormalizedDelta.x * mouseSensitivity, transform.localPosition.y + NonNormalizedDelta.y * mouseSensitivity);
    }

    public void SetPositionToDefault()
    {
        NonNormalizedDelta = new Vector2(0, 0);
        transform.localPosition = initialPosition;
        initialPosSet = true;
    }
}
