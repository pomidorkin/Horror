using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParamCube : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] int band = 0;
    [SerializeField] [Range(0f, 10f)] float animTriggerValue = 1.6f;
    private PlayerActions playerActions;
    private Door myChildDoor;
    float elapsedTime;
    float timeLimit = 0.1f;
    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
        myChildDoor = GetComponentInChildren<Door>();
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        /*if (AudioPeer.bandBuffer[band] > animTriggerValue)
        {
            gameObject.GetComponent<Animator>().Play("SlammAnimation");
        }*/
        if ( elapsedTime >= timeLimit && GetFMODSpectrumData.bandBuffer[band] > animTriggerValue && playerActions.lastLookedAtObject != myChildDoor.gameObject)
        {
            elapsedTime = 0;
            gameObject.GetComponent<Animator>().Play("SlammAnimation");
        }
    }
}