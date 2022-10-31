using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObstacle : MonoBehaviour
{
    private float rotationSpeed;
    private float minRotationSpeed = 40f;
    private float maxRotationSpeed = 70f;
    private Vector3 initialRotation;
    private bool firstTimeEnabled = true;

    private void OnEnable()
    {
        //transform.Rotate(initialRotation);
        if (!firstTimeEnabled)
        {
            transform.eulerAngles = initialRotation;
        }
        else
        {
            firstTimeEnabled = false;
            initialRotation = transform.rotation.eulerAngles;
        }
        Debug.Log("ParentObstacle enabled, initial rotation Z: " + initialRotation.z);
    }

    private void Start()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed + 1f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
