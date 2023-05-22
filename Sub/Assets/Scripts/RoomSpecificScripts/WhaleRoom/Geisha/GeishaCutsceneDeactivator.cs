using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeishaCutsceneDeactivator : MonoBehaviour
{
    [SerializeField] GameObject geishaCutscene;
    private void OnEnable()
    {
        geishaCutscene.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
