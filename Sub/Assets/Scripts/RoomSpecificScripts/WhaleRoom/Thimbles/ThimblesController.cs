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
    private float animLength;
    void Start()
    {
        animLength = (thimblesAnimations[0].length * 2f) + 0.1f;
        StartThimblesSequence();
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
                    animator.Play(thimblesAnimations[Random.Range(0, thimblesAnimations.Length)].name);
                    animLenghtCounter = 0.0f;
                    count++;
                    Debug.Log("count: " + count);
                }
            }
            else
            {
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

    private IEnumerator PlayBeginAnimCoroutine()
    {
        animator.Play("BeginAnim");
        yield return new WaitForSeconds(2f);
        playAnimTriggered = true;
    }
}
