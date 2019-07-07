using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit : MonoBehaviour
{
    bool cantBeHit = false;
    public float Time_whosUdady = 1;
    public float back_Distance = 5;
    public float speed = 1;
    float nextTime;
    Vector2 player_pos;
    Vector2 col_pos;
    public GameObject backGlod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cantBeHit)
        {
            if(Time.time-nextTime> Time_whosUdady)
            {
                cantBeHit = false;
                backGlod.SetActive(false);
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!cantBeHit)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                player_pos = this.gameObject.transform.position;
                col_pos = collision.transform.position;
                cantBeHit = true;
                StartCoroutine(BeHitted());
                nextTime = Time.time;
                Player_Control.Instance.player_health -= 10;
                Player_Control.Instance.GameOverCheck();
                BloodCTRL.bloodChange = -10;
                BloodCTRL.flag_cut = true;
                backGlod.SetActive(true);
                int index = Random.Range(5, 15);
                SEManager.Instance.PlaySE(index);
            }
        }
        
    }
    IEnumerator BeHitted()
    {
        Vector2 fwd = player_pos - col_pos;
        fwd = fwd.normalized;
        
        while (Vector2.Distance(this.gameObject.transform.position, player_pos) < back_Distance)
        {
            float distance = Vector2.Distance(this.gameObject.transform.position, player_pos);
            this.gameObject.transform.Translate(fwd * speed*(1- distance/ back_Distance));
            yield return 0;
        }
    }

}
