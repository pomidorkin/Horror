using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCollisionManager : MonoBehaviour
{
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "JellyFish")
        {
            Destroy(collision.gameObject);
        }
    }*/

    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "JellyFish")
        {
            Destroy(collision.gameObject);
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "JellyFish")
        {
            Destroy(other.gameObject);
        }
    }
}
