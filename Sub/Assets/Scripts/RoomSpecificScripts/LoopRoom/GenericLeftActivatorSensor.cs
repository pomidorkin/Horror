using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GenericLeftActivatorSensor : MonoBehaviour
{
    [SerializeField] GameObject bodyStage;
    [SerializeField] PlayableDirector playableDirector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //bodyStage.gameObject.SetActive(true);
            StartCoroutine(PlayDirector());
            bodyStage.gameObject.transform.eulerAngles = new Vector3(0, -90f, 0);
            bodyStage.gameObject.transform.localPosition = new Vector3(-1.280863f, 0.0f, 4.007f);
            //bodyStage.gameObject.transform.eulerAngles.y = -90f;
        }
    }

    private IEnumerator PlayDirector()
    {
        yield return new WaitForSeconds(1f);
        playableDirector.Play();
    }
}
