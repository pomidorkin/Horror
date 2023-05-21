using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeishaController : MonoBehaviour
{
    [SerializeField] GameObject bellObject;
    private bool bellPicked = false;
    [SerializeField] WhalseSceneRespawnManager whalseSceneRespawnManager;

    private void OnEnable()
    {
        whalseSceneRespawnManager.OnRespawnAction += Reset;
    }

    private void OnDisable()
    {
        whalseSceneRespawnManager.OnRespawnAction -= Reset;
    }

    private void Reset()
    {
        SetBellPicked(false);
    }

    public void SetBellPicked(bool val)
    {
        bellObject.SetActive(val);
        bellPicked = val;
    }
}
