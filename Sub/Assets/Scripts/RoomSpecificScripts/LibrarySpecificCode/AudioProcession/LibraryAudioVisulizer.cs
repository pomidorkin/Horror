using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryAudioVisulizer : MonoBehaviour
{
    [SerializeField] AudioVisualizerManager audioVisualizerManager;
    [SerializeField] GameObject positiveGroupParent;
    [SerializeField] GameObject negativeGroupParent;
    private bool switched = false;
    private void OnEnable()
    {
        audioVisualizerManager.OnPeakReachedAction += PeakReachedHandler;
    }

    private void OnDisable()
    {
        audioVisualizerManager.OnPeakReachedAction -= PeakReachedHandler;
    }

    private void PeakReachedHandler()
    {
        if (switched)
        {
            switched = false;
            positiveGroupParent.SetActive(true);
            negativeGroupParent.SetActive(false);
        }
        else
        {
            switched = true;
            negativeGroupParent.SetActive(true);
            positiveGroupParent.SetActive(false);
        }
        Debug.Log("Peak reached");
    }
}
