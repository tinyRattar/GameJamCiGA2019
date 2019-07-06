using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LookAt : MonoBehaviour
{
    Vector2 playerPos;
    Vector2 mousPos;
    Vector2 fwd;
    public List<Sprite> sp = new List<Sprite>();
    public List<GameObject> guns = new List<GameObject>();
    SpriteRenderer sr;
    public GameObject backGlod;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = this.gameObject.transform.position;
        mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        fwd = -playerPos + mousPos;
        SpriteRenderer[] sps = backGlod.GetComponentsInChildren<SpriteRenderer>();
        if ((fwd.x + fwd.y) > 0 && (fwd.y - fwd.x) < 0)
        {
            GunShow(0);
            sr.sprite = sp[0];
            foreach(SpriteRenderer temp in sps)
            {
                temp.sprite = sp[0];
            }
        }
        else if ((fwd.x + fwd.y) < 0 && (fwd.y - fwd.x) < 0)
        {
            GunShow(1);
            sr.sprite = sp[1];
            foreach (SpriteRenderer temp in sps)
            {
                temp.sprite = sp[1];
            }
        }
        else if ((fwd.x + fwd.y) < 0 && (fwd.y - fwd.x) > 0)
        {
            GunShow(2);
            sr.sprite = sp[2];
            foreach (SpriteRenderer temp in sps)
            {
                temp.sprite = sp[2];
            }
        }
        else if ((fwd.x + fwd.y) > 0 && (fwd.y - fwd.x) > 0)
        {
            GunShow(3);
            sr.sprite = sp[3];
            foreach (SpriteRenderer temp in sps)
            {
                temp.sprite = sp[3];
            }
        }
    }
    void GunShow(int index)
    {
        for(int i=0;i<4;i++)
        {
            guns[i].SetActive(false);
        }
        guns[index].SetActive(true);
    }
}
