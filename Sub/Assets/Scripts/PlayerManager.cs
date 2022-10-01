using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] bool wasScared = false;

    private void Start()
    {
        wasScared = false;
    }

    public void SetPlayerScared(bool value)
    {
        wasScared = value;
    }

    public bool GetPlayerScared()
    {
        return wasScared;
    }
}
