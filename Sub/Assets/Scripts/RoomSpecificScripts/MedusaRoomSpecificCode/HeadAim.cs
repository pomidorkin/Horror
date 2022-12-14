using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAim : MonoBehaviour
{
    [SerializeField] StoneEnemy[] targetObject;
    [SerializeField] float spellCastDuration = 2.0f;
    [SerializeField] RaycastHead raycastHead;
    [SerializeField] GuardsActivator guardsActivator;
    private float spellTimer = 0f;
    public int currentTarget = 0;
    private bool isInFocus = false;
    public bool headActivated = false;

    void Update()
    {
        if (headActivated)
        {
            if (!targetObject[currentTarget].isStone)
            {
                if (!isInFocus)
                {
                    isInFocus = true;
                    StartCoroutine(LerpPosition(targetObject[currentTarget].TargetLookPosition.position, .2f));

                }
                else
                {
                    if (spellTimer < spellCastDuration)
                    {
                        spellTimer += Time.deltaTime;
                        transform.position = targetObject[currentTarget].TargetLookPosition.position;
                    }
                    else
                    {
                        targetObject[currentTarget].TurnToStone();
                        spellTimer = 0f;
                        if (currentTarget < targetObject.Length - 1)
                        {
                            currentTarget++;
                        }
                        else
                        {
                            //raycastHead.MakeLaserActive(false);
                            //guardsActivator.DisableMedusaCollider();
                            //guardsActivator.activated = false;
                            guardsActivator.DeactivateMedusaLaser();
                        }
                        isInFocus = false;

                    }
                }

            }
        }
        
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    }
