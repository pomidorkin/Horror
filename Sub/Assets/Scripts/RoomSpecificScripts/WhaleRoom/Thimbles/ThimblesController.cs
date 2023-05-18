using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThimblesController : MonoBehaviour
{
    private bool playAnimTriggered = false;
    private float animLenghtCounter = 0.0f;
    private int count = 0;
    private int numberOfAnims = 7;
    [SerializeField] AnimationClip[] thimblesAnimations;
    [SerializeField] Animator animator;
    [SerializeField] GameObject flower;
    [SerializeField] GameObject fan;
    [SerializeField] GameObject emptyProp;
    Dictionary<string, int> positionDictionary;
    private int newValOne;
    private int newValTwo;
    private float animLength;
    [SerializeField] Vector3[] propsPositions;
    [SerializeField] GameObject thimblesGroup;
    [SerializeField] ParticleSystem explpsionParticle;
    [SerializeField] ThimblesParent thimblesParent;
    private Vector3 flowerInitialPos;
    private Vector3 fanInitialPos;
    private Vector3 emptyInitialPos;
    [SerializeField] BoxCollider[] propsInteraction;
    void Start()
    {
        animLength = (thimblesAnimations[0].length * 2f) + 0.1f;
        positionDictionary = new Dictionary<string, int>();
        positionDictionary.Add("one", 1);
        positionDictionary.Add("two", 2);
        positionDictionary.Add("three", 3);
        flowerInitialPos = flower.transform.localPosition;
        fanInitialPos = fan.transform.localPosition;
        emptyInitialPos = emptyProp.transform.localPosition;
    }

    private void Update()
    {
        if (playAnimTriggered)
        {
            if (count < numberOfAnims)
            {
                if (animLenghtCounter < animLength)
                {
                    animLenghtCounter += Time.deltaTime;
                }
                else
                {
                    int rnd = Random.Range(0, thimblesAnimations.Length);
                    Debug.Log("rnd: " + rnd);
                    animator.Play(thimblesAnimations[rnd].name);
                    switch (rnd)
                    {
                        case 0:
                            newValOne = positionDictionary["two"];
                            newValTwo = positionDictionary["one"];
                            positionDictionary["one"] = newValOne;
                            positionDictionary["two"] = newValTwo;
                            break;
                        case 1:
                            newValOne = positionDictionary["two"];
                            newValTwo = positionDictionary["three"];
                            positionDictionary["two"] = newValTwo;
                            positionDictionary["three"] = newValOne;
                            break;
                        case 2:
                            newValOne = positionDictionary["one"];
                            newValTwo = positionDictionary["three"];
                            positionDictionary["one"] = newValTwo;
                            positionDictionary["three"] = newValOne;
                            break;
                    }

                    animLenghtCounter = 0.0f;
                    count++;
                }
            }
            else
            {
                flower.transform.localPosition = propsPositions[positionDictionary["one"]-1];
                fan.transform.localPosition = propsPositions[positionDictionary["three"]-1];
                emptyProp.transform.localPosition = propsPositions[positionDictionary["two"] - 1];
                StartCoroutine(EnablePopsCoroutine());
                playAnimTriggered = false;
                animLenghtCounter = 0.0f;
                count = 0;
            }
        }
    }

    public void StartThimblesSequence()
    {
        StartCoroutine(PlayBeginAnimCoroutine());
    }

    public void StartEndSequence()
    {
        animator.Play("EndAnim");
    }

    private IEnumerator PlayBeginAnimCoroutine()
    {
        animator.Play("BeginAnim");
        yield return new WaitForSeconds(2f);
        flower.SetActive(false);
        fan.SetActive(false);
        emptyProp.SetActive(false);
        playAnimTriggered = true;
    }

    private IEnumerator EnablePopsCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        flower.SetActive(true);
        fan.SetActive(true);
        emptyProp.SetActive(true);
        foreach (BoxCollider interactionProp in propsInteraction)
        {
            interactionProp.enabled = true;
        }
    }

    public void HideThimblesGroup()
    {
        explpsionParticle.gameObject.transform.localPosition = thimblesGroup.transform.localPosition;
        explpsionParticle.gameObject.SetActive(true);
        thimblesGroup.SetActive(false);
        thimblesParent.SetNewPosition();
    }

    public void ResetThimbles()
    {
        flower.transform.localPosition = flowerInitialPos;
        fan.transform.localPosition = fanInitialPos;
        emptyProp.transform.localPosition = emptyInitialPos;
        animator.Play("BeginAnim");
        positionDictionary["one"] = 1;
        positionDictionary["two"] = 2;
        positionDictionary["three"] = 3;
        foreach (BoxCollider interactionProp in propsInteraction)
        {
            interactionProp.enabled = false;
        }
    }
}