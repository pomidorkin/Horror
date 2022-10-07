using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSpawner : MonoBehaviour
{
    private Vector3 initialSadakoPosition;
    [SerializeField] GameObject sadako;
    [SerializeField] GameObject sadakoEnemy;
    [SerializeField] GameObject sadakoPrefab;
    [SerializeField] GameObject parentEnemies;
    [SerializeField] ParticleSystem particleSystem;

    [SerializeField] public TVSpawnerParent TVSpawnerParent;
    [SerializeField] public Transform followObject;
    [SerializeField] public CameraLookController jumpScare;

    [SerializeField] BoxCollider interactionCollider;

    bool isAnimaPlaying = false;
    public bool crossIsPlaced = false;
    float maxTime = 5f;
    float counter = 0;

    private void OnEnable()
    {
        TVSpawnerParent.OnCrossPlaced += OnCrossPlacedHandler;
    }

    private void OnDisable()
    {
        
    }

    private void OnCrossPlacedHandler(object source, TVSpawnerParent.CrossPlacedEventArgs args)
    {
        if (args.IsCrossPlaced)
        {
            interactionCollider.enabled = false;
        }
        else
        {
            interactionCollider.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialSadakoPosition = sadako.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AvtivateSpawnerSequence()
    {
        particleSystem.Play();
        StartCoroutine(SadakoRealeaser());
        //ReleaseSadako();
    }

    private void ReleaseSadako()
    {
        if (!isAnimaPlaying && !crossIsPlaced)
        {
            isAnimaPlaying = true;
            interactionCollider.enabled = false;
            sadako.transform.position = initialSadakoPosition;
            sadako.SetActive(true);
        }
    }

    private IEnumerator SadakoRealeaser()
    {
        yield return new WaitForSeconds(4);
        ReleaseSadako();
    }

    public void SpawnSadakoEnemy()
    {
        isAnimaPlaying = false;
        interactionCollider.enabled = true;
        sadako.SetActive(false);
        // TODO: need to spawn here
        //sadakoEnemy.SetActive(true);
        GameObject obj = Instantiate(sadakoPrefab, sadakoEnemy.transform.position, sadakoEnemy.transform.rotation);
        obj.transform.SetParent(parentEnemies.transform);
        obj.GetComponent<AiAgent>().Init(followObject, jumpScare);
    }
}
