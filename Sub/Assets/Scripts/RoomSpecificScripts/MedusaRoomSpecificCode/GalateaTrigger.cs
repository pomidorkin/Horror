using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalateaTrigger : MonoBehaviour
{
    [SerializeField] private GalateaController galateaController;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter is executed");
        if (other.tag == "Galatea")
        {
            galateaController.StopMotion();
        }
    }
}
