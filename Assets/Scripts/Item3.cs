using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour
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
        Vector2 bulletPos = boom.transform.position;
        fwd = mousPos - bulletPos;
        fwd = fwd.normalized;
        boom.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(fwd.y / fwd.x) * Mathf.Rad2Deg);
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
                Destroy(this.gameObject, 0.5f);
            }
        }
    }
}
