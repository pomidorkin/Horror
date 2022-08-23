using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLB;

public class CorridorLightSource : MonoBehaviour
{
    // Может лагать
    private Light light;
    private Transform player;
    [SerializeField] private float lightOffDistance = 15f;
    private float sqrdLightOffDistance;
    private bool isFlickering = false;
    public bool triggeredFlickering = false;
    private float timeDelay = 0f;
    private float timeDelayCounter = 0f;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerMovement>().GetComponent<Transform>().transform;
        light = GetComponent<Light>();
    }

    private void Start()
    {
        sqrdLightOffDistance = lightOffDistance * lightOffDistance;
    }

    private void Update()
    {
        //light.intensity = 1.0f - (Mathf.InverseLerp(0, lightOffDistance * lightOffDistance, (transform.position.x - player.position.x) * (transform.position.x - player.position.x)); 
        
        if (triggeredFlickering)
        {
            FlickeringByTime();
        }
        else
        {
            light.intensity = 1.0f - (Mathf.InverseLerp(0, sqrdLightOffDistance, Mathf.Pow((transform.position.x - player.position.x), 2)));
        }
    }

    private void FlickeringByTime()
    {
        timeDelayCounter += Time.deltaTime;
        if (timeDelay == 0)
        {
            timeDelay = Random.Range(0.01f, 0.2f);
        }

        if (timeDelay >= timeDelayCounter)
        {
            if (!isFlickering)
            {
                isFlickering = true;
                light.intensity = 0;
            }
            else if (isFlickering)
            {
                isFlickering = false;
                light.intensity = 1.0f - (Mathf.InverseLerp(0, sqrdLightOffDistance, Mathf.Pow((transform.position.x - player.position.x), 2)));
            }
            timeDelayCounter = 0f;
            timeDelay = Random.Range(0.01f, 0.2f);
        }

    }
}
