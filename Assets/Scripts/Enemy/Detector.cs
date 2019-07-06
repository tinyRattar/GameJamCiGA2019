using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";
    GameObject target;

    public GameObject GetTarget()
    {
        return target;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == targetTag)
        {
            target = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            target = null;
        }
    }
}
