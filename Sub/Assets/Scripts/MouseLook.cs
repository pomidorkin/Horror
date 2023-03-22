using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 0.1f;
    [SerializeField] Transform playerBody;
    PlyerInputActions plyerInputActions;
    private Vector2 MouseMoveInput;
    float xRot;

    [SerializeField] private bool canMoveCamera = true;
    [SerializeField] CameraLookController jumpScare;
    [SerializeField] GameObject virtualCamera;
    [SerializeField] PauseMenu pauseMenu;

    [Header("Camera clamp settings")]
    [Range(-90, 0)]
    [SerializeField] float cameraMaxLook = -60f;
    [Range(0, 90)]
    [SerializeField] float cameraMinLook = 60f;


    private void Awake()
    {
        plyerInputActions = new PlyerInputActions();
        plyerInputActions.Player.Enable();
        plyerInputActions.Player.Look.performed += Look;
    }

    private void OnEnable()
    {
        jumpScare.OnCameraLookControllerEvent += DisableCameraMovement;
        pauseMenu.OnGamePausedAction += PauseCameraMovement;
    }

    private void OnDisable()
    {
        jumpScare.OnCameraLookControllerEvent -= DisableCameraMovement;
        plyerInputActions.Player.Look.performed -= Look;
        pauseMenu.OnGamePausedAction += PauseCameraMovement;
    }



    private void PauseCameraMovement(object source, PauseMenu.GamePausedEventArgs args)
    {
        if (!args.IsPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            DisableCameraMovement();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            EnableCameraMovement();
        }
    }

    public void EnableInputActions(bool enable)
    {
        if (enable)
        {
            plyerInputActions.Player.Enable();
        }
        else
        {
            plyerInputActions.Player.Disable();
        }
    }

    private void DisableCameraMovement(object source, CameraLookController.CameraLookControllerEventArgs args)
    {
        virtualCamera.gameObject.SetActive(true);
        canMoveCamera = false;
    }

    public void DisableCameraMovement()
    {
        //virtualCamera.gameObject.SetActive(true);
        canMoveCamera = false;
    }

    public void EnableCameraMovement()
    {
        //virtualCamera.gameObject.SetActive(false);
        canMoveCamera = true;
    }

    private void Look(InputAction.CallbackContext obj)
    {
        if (canMoveCamera)
        {
            Vector2 NonNormalizedDelta = MouseMoveInput * .5f * .1f;

            xRot -= NonNormalizedDelta.y * mouseSensitivity;
            xRot = Mathf.Clamp(xRot, cameraMaxLook, cameraMinLook);

            if (playerBody != null)
            {
                playerBody.Rotate(0f, NonNormalizedDelta.x * mouseSensitivity, 0f);
            }
            else
            {
                playerBody = FindObjectOfType<PlayerMovement>().gameObject.transform;
                playerBody.Rotate(0f, NonNormalizedDelta.x * mouseSensitivity, 0f);
            }

            //playerBody.Rotate(0f, NonNormalizedDelta.x * mouseSensitivity, 0f);
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void Update()
    {
        MouseMoveInput = plyerInputActions.Player.Look.ReadValue<Vector2>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
}
