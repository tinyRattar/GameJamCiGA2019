using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : OneHitSkill
{
    Vector3 fwd;
    public GameObject boom;
    public List<GameObject> bo = new List<GameObject>();
    public float speed = 0.01f;
    int cnt = 1;
    Vector2 corePos;
    public float distance = 2f;
    public float timeLast=0.5f;
    public float time_rate = 1;
    private float nextTime=0;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletPos = transform.position;
        fwd = mousPos - bulletPos;
        fwd = fwd.normalized;
        if(fwd.x>0)
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(fwd.y / fwd.x) * Mathf.Rad2Deg);
        else
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(fwd.y / fwd.x) * Mathf.Rad2Deg+180);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime + time_rate)
        {
            nextTime = Time.time;
        }
        if (Time.time > nextTime)
        {
            nextTime += time_rate;
            if (cnt < 5)
            {
                bo[cnt].SetActive(true);
                cnt++;
            }
            else
            {
                StartCoroutine(Show());
            }
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
        while (sp[0].color.a >0)
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
