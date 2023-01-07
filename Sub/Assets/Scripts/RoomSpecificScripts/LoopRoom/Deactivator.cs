using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    [SerializeField] GameObject loopRoomStage;
    private void OnEnable()
    {
        loopRoomStage.SetActive(false);
    }
}
