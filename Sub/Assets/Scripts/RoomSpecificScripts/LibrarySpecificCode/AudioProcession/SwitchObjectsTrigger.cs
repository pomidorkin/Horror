using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjectsTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] positiveObjects;
    [SerializeField] GameObject[] negativeObjects;

    public void TriggerChange(bool val)
    {
        Debug.Log("TriggerChange");
        foreach (GameObject obj in positiveObjects)
        {
            obj.SetActive(val);
        }
        foreach (GameObject obj in negativeObjects)
        {
            obj.SetActive(!val);
        }
    }
}
