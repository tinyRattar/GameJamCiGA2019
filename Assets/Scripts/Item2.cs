using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    Vector3 fwd;
    public GameObject item;
    public GameObject boom;
    public float speed = 0.01f;

    Vector2 corePos;
    public float distance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletPos = transform.position;
        fwd = mousPos - bulletPos;
        fwd = fwd.normalized;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(fwd.y / fwd.x) * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(boom.transform.position, corePos) < distance)
        {
            boom.transform.Translate(fwd * speed);
        }
        else
        {
            //boom.SetActive(false);
            Destroy(item, 0.5f);
        }
    }
}
