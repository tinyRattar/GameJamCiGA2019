using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float play_speed = 1;

    public List<GameObject> goBullet;
    public List<GameObject> goSkill1;
    public List<GameObject> goSkill2;
    public List<GameObject> goSkill3;
    private GameObject bullet;

    public float time_rate=1;
    private float nextTime;

    public List<float> coldTime;
    public List<float> nextSkill;
    int index = 0;
    public List<float> showColdTime;
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
        for (int i = 0; i < 3; i++)
            SkillShot(i);
    }
    void SkillShot(int i)
    {
        KeyCode kc= KeyCode.Alpha1;
        GameObject item=null;
        if (i == 0)
        {
            kc = KeyCode.Alpha1;
            item = goSkill1[index];
        }
        else if (i == 1)
        {
            kc = KeyCode.Alpha2;
            item = goSkill2[index];
        }
        else if (i == 2)
        {
            kc = KeyCode.Alpha3;
            item = goSkill3[index];
        }
        if (Time.time > nextSkill[i] + coldTime[i])
        {
            nextSkill[i] = Time.time;
        }
        else if (Time.time > nextSkill[i])
        {
            if (Input.GetKeyDown(kc))//技能1
            {
                Instantiate(item, transform.position, transform.rotation);//将预制体生成对象
                nextSkill[i] += coldTime[i];
            }
        }
        else
        {
            showColdTime[i] = nextSkill[i] - Time.time;
            //print(nextSkill - Time.time);
        }
    }


}
