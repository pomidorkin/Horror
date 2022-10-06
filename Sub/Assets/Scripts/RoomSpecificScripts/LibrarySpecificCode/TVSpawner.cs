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

    [SerializeField] public Transform followObject;
    [SerializeField] public CameraLookController jumpScare;

    float maxTime = 5f;
    float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialSadakoPosition = sadako.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < maxTime)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            //sadako.SetActive(false);
            sadako.transform.position = initialSadakoPosition;
            sadako.SetActive(true);
        }
    }

    public void SpawnSadakoEnemy()
    {
        sadako.SetActive(false);
        // TODO: need to spawn here
        //sadakoEnemy.SetActive(true);
        GameObject obj = Instantiate(sadakoPrefab, sadakoEnemy.transform.position, sadakoEnemy.transform.rotation);
        obj.transform.SetParent(parentEnemies.transform);
        obj.GetComponent<AiAgent>().Init(followObject, jumpScare);
    }
}
