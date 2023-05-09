using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using TMPro;


public class SubtitleManager : MonoBehaviour
{
    public LocalizedString[] localizedInteractionText;
    [SerializeField] TMP_Text subtitleText;
    private int counter = 0;

    private void OnEnable()
    {
        if (true /*Check if Subtitles are activated in menu*/)
        {
            if (counter == 0 && !subtitleText.gameObject.activeInHierarchy)
            {
                subtitleText.gameObject.SetActive(true);
            }
            subtitleText.text = localizedInteractionText[counter].GetLocalizedString();
        }
    }

    private void OnDisable()
    {
        counter++;
        Debug.Log("counter: " + counter + ", localizedInteractionText.Length: " + localizedInteractionText.Length);
        if (counter >= localizedInteractionText.Length)
        {
            subtitleText.gameObject.SetActive(false);
            counter = 0;
        }
    }
}
