using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour
{
    public static Player_Control Instance;
    public float player_health = 100;
    public float play_speed = 1;

    public List<GameObject> goBullet;
    public List<GameObject> goSkill1;
    public List<GameObject> goSkill2;
    public List<GameObject> goSkill3;
    private GameObject bullet;

    public float time_rate=1;
    private float nextTime;

    public List<float> coldTime;
    int index = 0;
    public List<float> timerCold;
    public List<int> listSkillNum;

    UISkillManager uiSkillManager;

    public void GameOverCheck()
    {
        if (player_health <= 0)
        {
            SceneManager.LoadScene(3);
            PortalMissionManager.Instance.onGameOver = true;
        }
            
    }

    public void AddSkillNum(int index, int value)
    {
        listSkillNum[index] += value;
        UpdateUISkillNum();
    }

    void UpdateUISkillNum()
    {
        for (int i = 0; i < 3; i++)
        {
            uiSkillManager.SetSkillNum(i, listSkillNum[i]);
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More Than two instance");
        }
        
        uiSkillManager = GameObject.Find("UISkillManager").GetComponent<UISkillManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateUISkillNum();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))//上移动
        {
            //transform.position += transform.up * play_speed * Time.deltaTime ;
            this.transform.Translate(Vector3.up * play_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))//下移动
        {
            //ransform.position += -transform.up * play_speed * Time.deltaTime;
            this.transform.Translate(Vector3.down * play_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))//左移动
        {
            //transform.position += -transform.right * play_speed * Time.deltaTime;
            this.transform.Translate(Vector3.left * play_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))//右移动
        {
            //transform.position += transform.right * play_speed * Time.deltaTime;
            this.transform.Translate(Vector3.right * play_speed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//左切武器移动
        {
            index--;
            if (index < 0)
                index = 2;
            UIWeaponManager.Instance.SwitchLeft();
        }
        if (Input.GetKeyDown(KeyCode.Q))//右切武器移动
        {
            index++;
            if (index > 2)
                index = 0;
            UIWeaponManager.Instance.SwitchRight();
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
        /*
        if (Input.GetKey(KeyCode.W))//上移动
        {
            //transform.position += transform.up * play_speed * Time.deltaTime ;
            this.transform.Translate(Vector3.up * play_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))//下移动
        {
            //ransform.position += -transform.up * play_speed * Time.deltaTime;
            this.transform.Translate(Vector3.down * play_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))//左移动
        {
            //transform.position += -transform.right * play_speed * Time.deltaTime;
            this.transform.Translate(Vector3.left * play_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))//右移动
        {
            //transform.position += transform.right * play_speed * Time.deltaTime;
            this.transform.Translate(Vector3.right * play_speed * Time.deltaTime);
        }*/
        if(Input.GetKeyDown(KeyCode.Alpha1))
            SkillShot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SkillShot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SkillShot(2);
        for (int i = 0; i < 3; i++)
        {
            timerCold[i] -= Time.deltaTime;
            if (timerCold[i] < -10f)
                timerCold[i] = 0;
        }
    }
    void SkillShot(int i)
    {
        
        if (listSkillNum[i] <= 0)
            return;
        SEManager.Instance.PlaySE(i + 15);
        GameObject item=null;
        if (i == 0)
        {
            item = goSkill1[index]; 
        }
        else if (i == 1)
        {
            item = goSkill2[index];
        }
        else if (i == 2)
        {
            item = goSkill3[index];
        }

        if (timerCold[i] < 0)
        {
            Instantiate(item, transform.position, transform.rotation);//将预制体生成对象
            timerCold[i] = coldTime[i];
            uiSkillManager.StartSkillCD(i, coldTime[i]);
            listSkillNum[i] -= 1;
            UpdateUISkillNum();
        }
    }


}
