using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenseSensor : MonoBehaviour
{
    [SerializeField] GameObject parentRoomStage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parentRoomStage.gameObject.SetActive(false);
        }
    }
}
