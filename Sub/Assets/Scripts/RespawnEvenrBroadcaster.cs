using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEvenrBroadcaster : MonoBehaviour
{
    public delegate void RespawnTriggeredACtion();
    public event RespawnTriggeredACtion OnRespawnTriggeredAction;

    public void InvokeRespawnAction()
    {
        //aiSensor.EnableSecondEnemy();
        OnRespawnTriggeredAction();
    }
}
