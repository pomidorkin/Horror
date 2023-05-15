using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCeiling : MonoBehaviour
{
    [SerializeField] float movingSpeed = -.01f;
    [SerializeField] MainSceneRespawnManager respawnManager;
    [SerializeField] RoomLeavingSensor roomLeavingSensor;
    [SerializeField] RoomEnteringSensor roomEnteringSensor;
    [SerializeField] LeverPuzzle leverPuzzle;
    private Vector3 initialPosition;
    private bool movingEnabled = false;
    private void Start()
    {
        initialPosition = transform.localPosition;
    }
    void Update()
    {
        if (movingEnabled)
        {
            transform.localPosition += new Vector3(0, movingSpeed, 0) * Time.deltaTime;
        }
    }

    public void ResetPosition()
    {
        movingEnabled = false;
        transform.localPosition = initialPosition;
    }

    public void EnableMoving()
    {
        movingEnabled = true;
    }

    public void DisableMoving()
    {
        movingEnabled = false;
    }

    private void OnEnable()
    {
        leverPuzzle.ResetPuzzle();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Colliding with player");
            ResetPosition();
            ResetSensors();
            //leverPuzzle.ResetPuzzle();
            //RespawnPlayer
            respawnManager.Respawn();
        }
    }

    private void ResetSensors()
    {
        roomEnteringSensor.gameObject.SetActive(true);
        roomLeavingSensor.gameObject.SetActive(false);
    }
}