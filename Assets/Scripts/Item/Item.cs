using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    bool canTaken = true;

    public virtual void OnTaken(Collider2D collision)
    {
        this.GetComponent<Animation>().Play("ItemTaken");
        SEManager.Instance.PlaySE(18);
        canTaken = false;
        Destroy(this.gameObject, 1.5f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTaken)
        {
            if (collision.tag == "Player")
            {
                OnTaken(collision);
            }
        }
    }
}
