using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : OneHitSkill
{
    Vector3 fwd;
    public GameObject core;
    public GameObject boom;
    public float speed = 2f;
    Vector2 corePos;
    public float distance = 2f;
    public float flyTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        corePos = transform.position;
        fwd = mousPos - corePos;
        fwd = fwd.normalized;
        this.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(flyTime > Time.deltaTime)
        {
            this.transform.Translate(fwd * speed * Time.deltaTime);
            flyTime -= Time.deltaTime;
        }
        else if (flyTime>0)
        {
            this.transform.Translate(fwd * speed * flyTime);
            flyTime = 0f;
        }
        /*
        if (Vector2.Distance(core.transform.position, corePos) < distance)
        {
            core.transform.Translate(fwd * speed * Time.deltaTime);
        }
        else
        {
            //boom.transform.position = core.transform.position;
            //core.SetActive(false);
            //boom.SetActive(true);
            //StartCoroutine(Show()); 
        }*/
    }

    IEnumerator Show()
    {
        SpriteRenderer[] sp = boom.GetComponentsInChildren<SpriteRenderer>();
        int len = sp.Length;
        while (sp[0].color.a>0)
        {
            foreach (SpriteRenderer ssp in sp)
            {
                ssp.color = new Color(ssp.color.r, ssp.color.g, ssp.color.b, ssp.color.a - 0.05f);
            }
            yield return 0;
        }
        while(sp[0].color.a <1)
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
