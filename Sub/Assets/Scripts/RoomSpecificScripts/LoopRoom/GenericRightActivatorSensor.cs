using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GenericRightActivatorSensor : MonoBehaviour
{
    [SerializeField] GameObject bodyStage;
    [SerializeField] PlayableDirector playableDirector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayDirector());
            bodyStage.gameObject.SetActive(true);
        }
    }

    private IEnumerator PlayDirector()
    {
        yield return new WaitForSeconds(1f);
        playableDirector.Play();
    }
}
