using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public delegate void MonsterHitAction();
    public event MonsterHitAction OnMonsterHitAction;

    public void HitPerformed()
    {
        OnMonsterHitAction();
    }
}
