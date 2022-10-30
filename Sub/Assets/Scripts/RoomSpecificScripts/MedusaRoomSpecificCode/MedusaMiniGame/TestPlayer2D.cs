using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer2D : MonoBehaviour
{
    [SerializeField] TestMiniGameController inputController;
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject boundaries;
    [SerializeField] float speed = 12f;
    private Vector3 initialPosition;

    //PlyerInputActions playerInputActions;
    private void Awake()
    {
        //playerInputActions = inputController.GetInputActions();
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        //Vector2 inputVector = playerInputActions.MedusaMiniGame.Movement.ReadValue<Vector2>();
        Vector2 inputVector = inputController.GetInputActions().MedusaMiniGame.Movement.ReadValue<Vector2>();
        //float x = inputVector.x;
        float x = 0; // I don't want to move the player along the x axis
        float z = inputVector.y;
        Vector2 move = transform.right * x + transform.up * z;
        if ((transform.position.y > Mathf.Min(0 - (boundaries.transform.localScale.y / 2f), (boundaries.transform.localScale.y / 2f)) && transform.position.y < Mathf.Max(0 - (boundaries.transform.localScale.y / 2f), (boundaries.transform.localScale.y / 2f))) ||
            (transform.position.y > Mathf.Min(0 - (boundaries.transform.localScale.y / 2f), (boundaries.transform.localScale.y / 2f)) && z == -1) || (transform.position.y < Mathf.Max(0 - (boundaries.transform.localScale.y / 2f), (boundaries.transform.localScale.y / 2f)) && z == 1))
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        
    }

    public void SetPositionToDefault()
    {
        transform.position = initialPosition;
    }
}
