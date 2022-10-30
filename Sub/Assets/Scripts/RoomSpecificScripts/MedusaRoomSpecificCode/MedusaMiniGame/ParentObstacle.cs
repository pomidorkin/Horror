using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObstacle : MonoBehaviour
{
    private float rotationSpeed;
    private float minRotationSpeed = 40f;
    private float maxRotationSpeed = 70f;

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
