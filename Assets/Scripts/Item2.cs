using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    Vector3 fwd;
    public GameObject boom;
    public float speed = 0.01f;

    Vector2 corePos;
    public float distance = 2f;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        corePos = transform.position;
        fwd = mousPos - corePos;
        fwd = fwd.normalized;

        angle = Mathf.Atan(fwd.y / fwd.x);
        boom.transform.eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, corePos) < distance)
        {
            transform.Translate(fwd * speed);
        }
        else
        {
            //boom.SetActive(false);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
