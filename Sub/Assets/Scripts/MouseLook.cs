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

    private bool canMoveCamera = true;
    [SerializeField] JumpScare jumpScare;
    [SerializeField] GameObject virtualCamera;

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
        jumpScare.OnJumpScareEvent += DisableCameraMovement;
    }

    private void OnDisable()
    {
        jumpScare.OnJumpScareEvent -= DisableCameraMovement;
    }

    private void DisableCameraMovement(object source, JumpScare.JumpScareEventArgs args)
    {
        virtualCamera.gameObject.SetActive(true);
        canMoveCamera = false;
    }

    private void Look(InputAction.CallbackContext obj)
    {
        if (canMoveCamera)
        {
            Vector2 NonNormalizedDelta = MouseMoveInput * .5f * .1f;

            xRot -= NonNormalizedDelta.y * mouseSensitivity;
            xRot = Mathf.Clamp(xRot, cameraMaxLook, cameraMinLook);

            playerBody.Rotate(0f, NonNormalizedDelta.x * mouseSensitivity, 0f);
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
    }

    void Update()
    {
        MouseMoveInput = plyerInputActions.Player.Look.ReadValue<Vector2>();
    }
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

    }
}
