using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorStageOne : MonoBehaviour
{
    [SerializeField] AllDoorController allDoorController;
    [SerializeField] GameObject corridorStageObject;
    private void OnEnable()
    {
        corridorStageObject.gameObject.SetActive(true);
    }

    private void Start()
    {
        allDoorController.MakeAllDoorsInteractable(false);
    }
}
