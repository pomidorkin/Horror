using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FacialAnimations/FacialAnim Set")]
public class FacialAnimationsSet : ScriptableObject
{
    [SerializeField] private Vector3 Neutral;
    [SerializeField] private Vector3 Angry;
    [SerializeField] private Vector3 Sad;

    public Vector3 GetEyeBrowPosition(FacialExpression facialExpression)
    {
        switch (facialExpression)
        {
            case FacialExpression.Neutral:
                return Neutral;
            case FacialExpression.Angry:
                return Angry;
            case FacialExpression.Sad:
                return Sad;
        }

        return Neutral;
    }
}
