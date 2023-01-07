using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GenericLeftActivatorSensor : MonoBehaviour
{
    [SerializeField] GameObject bodyStage;
    [SerializeField] GameObject animActivatingSesor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // bodyStage.gameObject.SetActive(true);
            animActivatingSesor.gameObject.SetActive(true);
            bodyStage.gameObject.transform.eulerAngles = new Vector3(0, -90f, 0);
            bodyStage.gameObject.transform.localPosition = new Vector3(0, 0.0f, 4.007f);
            //bodyStage.gameObject.transform.eulerAngles.y = -90f;
        }
    }
}
