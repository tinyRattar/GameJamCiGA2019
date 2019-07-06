using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Protal_Defend : MonoBehaviour
{
    public float speed = 1;
    public Transform player;
    public float radis = 5f;
    public GameObject timeRing;
    Transform ring;
    Image img;
    bool enterFlag = false;
    public List<GameObject> frags = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ring = timeRing.gameObject.transform.Find("Ring");
        img = ring.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enterFlag)
        {
            img.fillAmount -= 0.5f*Time.deltaTime;
        }
        if(img.fillAmount<0.0001)
        {
            Dismiss();
            Destroy(this.gameObject, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            enterFlag = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enterFlag = false;
    }
    void Dismiss()
    {
        timeRing.SetActive(false);
        frags[4].SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            float angle = Random.Range(i * 90f, (i+1) * 90f)*Mathf.Deg2Rad;
            Vector2 fwd = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            frags[i].SetActive(true);
            frags[i].transform.Translate(fwd * speed * Time.deltaTime);
        }
    }
}
