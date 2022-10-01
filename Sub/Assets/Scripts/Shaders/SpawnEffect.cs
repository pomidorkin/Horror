using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    // First model
    [SerializeField] GameObject firstModel;
    [SerializeField] GameObject[] accesoirs;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material originalMaterial;
    //[SerializeField] private Material dissolveMaterial;
    [SerializeField] private Material phaseMaterial;

    // TODO
    [SerializeField] private Material firstModelReversePhase;


    // Second Model
    [SerializeField] GameObject secondModel;
    [SerializeField] private Renderer _secondRenderer;
    [SerializeField] private Material secondModelOriginalMaterial;
    [SerializeField] private Material secondModelPhaseMaterial; // Reversed shader material

    [SerializeField] private Material secondModelReversePhase;


    [SerializeField] private float fadeTime = 2f;

    [SerializeField] bool TEST_BUTTON_DELETE_ME = false;

    private bool fadeBackwards = false;
    // Start is called before the first frame update
    void Start()
    {
        _renderer.material = phaseMaterial;
        DoFade(0, 2, 0);
    }

    public void DoFade(float start, float dest, float time)
    {
        firstModel.SetActive(true);
        secondModel.SetActive(true);
        foreach (GameObject accesoir in accesoirs)
        {
            accesoir.SetActive(false);
        }
        //accesoirs.SetActive(false);
        if (fadeBackwards)
        {
            //_renderer.material = secondModelPhaseMaterial;
            _renderer.material = firstModelReversePhase;
            //_secondRenderer.material = phaseMaterial;
            _secondRenderer.material = secondModelPhaseMaterial;
        }
        else
        {
            //_secondRenderer.material = secondModelPhaseMaterial;
            _secondRenderer.material = secondModelReversePhase;
            _renderer.material = phaseMaterial;
            //accesoirs.SetActive(false);
            foreach (GameObject accesoir in accesoirs)
            {
                accesoir.SetActive(false);
            }
        }
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", start, "to", dest, "time", time, "onupdatetarget", gameObject,
            "onupdate", "TweenOnUpdate", "oncomplete", "TweenOnComplete", "easetype", iTween.EaseType.easeInOutCubic
            ));
    }

    void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat("_SplitValue", value);
        _secondRenderer.material.SetFloat("_SplitValue", value);
    }

    void TweenOnComplete()
    {
        if (!fadeBackwards)
        {
            _renderer.material = originalMaterial;
            firstModel.SetActive(true);
            //accesoirs.SetActive(true);
            foreach (GameObject accesoir in accesoirs)
            {
                accesoir.SetActive(true);
            }
            secondModel.SetActive(false);
            //_secondRenderer.material = 
        }
        else
        {
            _secondRenderer.material = originalMaterial;
            firstModel.SetActive(false);
            secondModel.SetActive(true);
            this.GetComponent<AiAgent>().stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
        
        //_secondRenderer.material = originalMaterial;
        fadeBackwards = !fadeBackwards;
    }

    private void Update()
    {
        if (TEST_BUTTON_DELETE_ME)
        {
            DoFade(0, 2, fadeTime);
            TEST_BUTTON_DELETE_ME = false;
        }
    }
}
