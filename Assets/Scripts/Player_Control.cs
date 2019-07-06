using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float play_speed = 1;

    public GameObject goBullet;
    private GameObject bullet;

    public float time_rate=1;
    private float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))//上移动
        {
            transform.position += transform.up * play_speed ;
        }
        if(Input.GetKey(KeyCode.S))//下移动
        {
            transform.position += -transform.up * play_speed;
        }
        if (Input.GetKey(KeyCode.A))//左移动
        {
            transform.position += -transform.right * play_speed;
        }
        if (Input.GetKey(KeyCode.D))//右移动
        {
            transform.position += transform.right * play_speed;
        }

        if(Input.GetMouseButton(0))//子弹发射
        {
            if (Time.time > nextTime + time_rate)
            {
                nextTime = Time.time;
            }
            else if (Time.time > nextTime)
            {
                nextTime += time_rate;
                bullet = Instantiate(goBullet, transform.position, transform.rotation);//将预制体生成对象
            }
            
        }
    }


}
