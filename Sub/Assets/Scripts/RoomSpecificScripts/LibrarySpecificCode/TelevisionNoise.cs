using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionNoise : MonoBehaviour
{
    [SerializeField] Material noiseMaterial;
    float scrollSpeed = 0.5f;

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        noiseMaterial.mainTextureOffset = new Vector2(0, -offset);
    }
}
