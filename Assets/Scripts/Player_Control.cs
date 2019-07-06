using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float play_speed = 1;

    public List<GameObject> goBullet;
    private GameObject bullet;

    public float time_rate=1;
    private float nextTime;

    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))//左切武器移动
        {
            index--;
            if (index < 0)
                index = 2;
        }
        if (Input.GetKeyDown(KeyCode.E))//右切武器移动
        {
            index++;
            if (index > 2)
                index = 0;
        }
        if (Time.time > nextTime + time_rate)
        {
            nextTime = Time.time;
        }
        else if (Time.time > nextTime)
        {
            nextTime += time_rate;

            if (Input.GetMouseButton(0))//子弹发射
            {
                bullet = Instantiate(goBullet[index], transform.position, transform.rotation);//将预制体生成对象
            }
        }

        if (Input.GetKey(KeyCode.W))//上移动
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
        if(Input.GetKeyDown(KeyCode.Alpha1))//技能1
        {
            
        }
    }


}
