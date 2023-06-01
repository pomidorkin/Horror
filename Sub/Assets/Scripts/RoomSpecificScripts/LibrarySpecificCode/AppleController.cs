using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    [SerializeField] private Target target;
    [SerializeField] private int healAmount = 50;
    [SerializeField] TreeController treeController;
    private Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void HealHarget()
    {
        target.HealTarget(healAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HealHarget();
            EnableCollider(false);
            treeController.ResetApplePosition();
        }
    }

    public void ActionAfterTweenComplete()
    {
        EnableCollider(true);
    }

    public void EnableCollider(bool val)
    {
        collider.enabled = val;
    }
}
