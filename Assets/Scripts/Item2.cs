using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : OneHitSkill
{
    Vector3 fwd;
    public GameObject boom;
    public float speed = 0.1f;

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
            StartCoroutine(Show());
        }
    }
    IEnumerator Show()
    {
        SpriteRenderer[] sp = boom.GetComponentsInChildren<SpriteRenderer>();
        int len = sp.Length;
        while (sp[0].color.a > 0)
        {
            foreach (SpriteRenderer ssp in sp)
            {
                ssp.color = new Color(ssp.color.r, ssp.color.g, ssp.color.b, ssp.color.a - 0.05f);
            }
            yield return 0;
        }
        while (sp[0].color.a < 1)
        {
            foreach (SpriteRenderer ssp in sp)
            {
                ssp.color = new Color(ssp.color.r, ssp.color.g, ssp.color.b, ssp.color.a + 0.05f);
            }
            yield return 0;
        }
        while (sp[0].color.a > 0)
        {
            foreach (SpriteRenderer ssp in sp)
            {
                ssp.color = new Color(ssp.color.r, ssp.color.g, ssp.color.b, ssp.color.a - 0.1f);
            }
            yield return 0;
        }
        Destroy(this.gameObject, 0.5f);
    }
}
