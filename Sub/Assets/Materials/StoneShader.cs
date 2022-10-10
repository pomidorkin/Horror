using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneShader : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material phaseMaterial;
    [SerializeField] private float fadeTime = 5f;
    [SerializeField] bool TEST_BUTTON_DELETE_ME = false;
    private bool fadeBackwards = false;
    private float startValue = 1.1f;
    private float destValue = -.1f;
    private bool inProcess = false;
    void Start()
    {
        _renderer.material = phaseMaterial;
        //DoFade(startValue, destValue, fadeTime);
    }

    public void DoFade(float start, float dest, float time)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", start, "to", dest, "time", time, "onupdatetarget", gameObject,
            "onupdate", "TweenOnUpdate", "oncomplete", "TweenOnComplete", "easetype", iTween.EaseType.easeInOutCubic
            ));
    }

    void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat("_ChangeValue", value);
    }

    void TweenOnComplete()
    {
        //fadeBackwards = !fadeBackwards;
        inProcess = false;
    }

    private void Update()
    {
        if (TEST_BUTTON_DELETE_ME && !inProcess)
        {
            inProcess = true;
            if (fadeBackwards)
            {
                DoFade(destValue, startValue, fadeTime);
            }
            else
            {
                DoFade(startValue, destValue, fadeTime);
            }
            fadeBackwards = !fadeBackwards;
            TEST_BUTTON_DELETE_ME = false;
        }
    }
}
