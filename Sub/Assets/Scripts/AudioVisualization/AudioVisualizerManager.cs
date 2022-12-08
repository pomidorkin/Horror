using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class AudioVisualizerManager : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] int band = 0;
    [SerializeField] [Range(0f, 10f)] float animTriggerValue = 1.6f;
    private GameManagerScript gameManager;
    [SerializeField] private MMFeedbacks MMFeedbacks;
    float elapsedTime;
    float timeLimit = 0.1f;

    public delegate void PeakReachedAction();
    public event PeakReachedAction OnPeakReachedAction;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        /*if (AudioPeer.bandBuffer[band] > animTriggerValue)
        {
            gameObject.GetComponent<Animator>().Play("SlammAnimation");
        }*/

        

        if (elapsedTime >= timeLimit && GetFMODSpectrumData.bandBuffer[band] > animTriggerValue && !gameManager.GetIsRespawningStage())
        {
            elapsedTime = 0;
            OnPeakReachedAction();
            //MMFeedbacks.PlayFeedbacks();
            Debug.Log("AudioVisualizerManager triggered");
        }
    }
}
