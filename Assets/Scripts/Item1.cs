using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    Vector3 fwd;
    public GameObject core;
    public GameObject boom;
    public float speed = 0.01f;
    Vector2 corePos;
    public float distance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        corePos = transform.position;
        fwd = mousPos - corePos;
        fwd = fwd.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(core.transform.position, corePos) < distance)
        {
            core.transform.Translate(fwd * speed);
        }
        else
        {
            boom.transform.position = core.transform.position;
            core.SetActive(false);
            boom.SetActive(true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
