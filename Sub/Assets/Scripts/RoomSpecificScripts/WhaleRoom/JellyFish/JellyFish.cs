using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] JellyFishSpawner jellyFishSpawner;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] GameObject jellyFishMesh;
    private AllTankController allTankController;
    private Transform target;
    private bool canMove = true;

    private void OnEnable()
    {
        jellyFishSpawner = FindObjectOfType<JellyFishSpawner>();
        allTankController = jellyFishSpawner.GetAllTankController();
        allTankController.OnAllTanksDisabled += AllTanksDisabledHandler;
    }

    private void OnDisable()
    {
        allTankController.OnAllTanksDisabled -= AllTanksDisabledHandler;
    }

    private void AllTanksDisabledHandler()
    {
        JellyfishDieSequence();
    }

    private void Start()
    {
        //jellyFishSpawner = FindObjectOfType<JellyFishSpawner>();
        this.target = jellyFishSpawner.target;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) > 10f && canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            JellyfishDieSequence();
        }
    }

    private void JellyfishDieSequence()
    {
        canMove = false;
        particleSystem.gameObject.SetActive(true);
        jellyFishMesh.SetActive(false);
        StartCoroutine(DestroyThisObject());
    }

    private IEnumerator DestroyThisObject()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
