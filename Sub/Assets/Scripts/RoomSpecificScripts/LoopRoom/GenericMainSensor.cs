using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMainSensor : MonoBehaviour
{
    [SerializeField] GameObject bodyStageSensors;
    [SerializeField] GameObject body;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bodyStageSensors.gameObject.SetActive(true);
            body.gameObject.SetActive(true);
        }
    }
}
