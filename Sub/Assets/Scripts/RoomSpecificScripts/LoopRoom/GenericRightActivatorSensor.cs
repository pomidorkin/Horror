using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GenericRightActivatorSensor : MonoBehaviour
{
    [SerializeField] GameObject bodyStage;
    [SerializeField] GameObject animActivatingSesor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //bodyStage.gameObject.SetActive(true);
            animActivatingSesor.gameObject.SetActive(true);
        }
    }
}
