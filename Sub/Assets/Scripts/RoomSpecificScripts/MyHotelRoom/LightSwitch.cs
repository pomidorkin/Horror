using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] GameObject[] monsterVersions;
    private bool isOn = true;
    private int counter;

    public void ToggleSwitchOnOff()
    {
        isOn = !isOn;
        if (!isOn)
        {
            monsterVersions[counter].SetActive(true);
            counter++;
        }
        else
        {
            foreach (GameObject monsterVersion in monsterVersions)
            {
                monsterVersion.SetActive(false);
            }
        }
    }
}
