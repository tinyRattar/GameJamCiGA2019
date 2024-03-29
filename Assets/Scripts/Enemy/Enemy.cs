﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health;
    [SerializeField] GameObject target;
    Vector2 defaultMoveDirection;
    float defaultMoveSpeedScale = 1.0f;
    float totalDropItemProp = 0;
    bool isAlive = true;

    [SerializeField] ElementType elementType;
    [SerializeField] int maxHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] float randomDirectionResetTime = 2.0f;

    [SerializeField] List<GameObject> dropItemList;
    [SerializeField] List<float> dropItemPropList;
    float timerRDRT = 0;
    Detector detector;

    [SerializeField] float hitFlashTime = 0.5f;
    float timerHitFlash = 0f;
    bool inHitFlash = false;

    [SerializeField] float deadTime = 0.5f;
    float timerDead = 0f;

    SpriteRenderer sr;

    #region debug
    [SerializeField] bool KillIt = false;
    #endregion

    void SetRandomDirection()
    {
        float angle = Random.Range(0, 360f);
        defaultMoveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    void SetRandomSpeedScale()
    {
        defaultMoveSpeedScale = Random.Range(0, 1f);
    }

    void DropRandomItem()
    {
        float r = Random.Range(0, totalDropItemProp);
        for(int index = 0;index < dropItemList.Count; index++)
        {
            if (dropItemPropList[index] >= r)
            {
                if (dropItemList[index] != null)
                    GameObject.Instantiate(dropItemList[index], this.transform.position, new Quaternion());
                break;
            }
            r -= dropItemPropList[index];
        }
    }

    void OnKill()
    {
        isAlive = false;
        timerDead = deadTime;
        DropRandomItem();
        this.GetComponent<Rigidbody2D>().simulated = false;
        Destroy(this.gameObject, 1.0f);
    }

    void ScaleWithHealth()
    {
        if (health <= maxHealth)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            float scale = (float)health / maxHealth;
            this.transform.localScale = new Vector3(scale, scale, 1);
        }
    }

    public bool OnHit(int value, ElementType type = ElementType.None)
    {
        if (isAlive)
        {
            int index = Random.Range(0, 5);
            SEManager.Instance.PlaySE(index);
            float effect = Util.CalcElementEffect(type, elementType);
            health -= (int)(effect * value);

            inHitFlash = true;
            timerHitFlash = hitFlashTime;

            if (health <= 0)
            {
                OnKill();
            }
            ScaleWithHealth();
            return true;
        }
        return false;
    }

    public void DefaultMove()
    {
        if(target == null)
        {
            if (timerRDRT <= 0)
            {
                SetRandomSpeedScale();
                SetRandomDirection();
                timerRDRT = randomDirectionResetTime;
            }
            else
            {
                timerRDRT -= Time.deltaTime;
            }
            this.transform.Translate(defaultMoveDirection * moveSpeed * Time.deltaTime * defaultMoveSpeedScale);
        }
        else
        {
            Vector3 direct = (target.transform.position - this.transform.position).normalized;
            this.transform.Translate(direct * moveSpeed * Time.deltaTime);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach (float prop in dropItemPropList)
        {
            totalDropItemProp += prop;
        }
        health = maxHealth;
        //target = GameObject.FindGameObjectWithTag("Player");
        detector = this.GetComponentInChildren<Detector>();
        EnemyBirthControl.Instance.CountUp();
        sr = this.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            DefaultMove();
            target = detector.GetTarget();
            if (inHitFlash)
            {
                timerHitFlash -= Time.deltaTime;
                if (timerHitFlash <= 0)
                {
                    timerHitFlash = 0;
                    inHitFlash = false;
                }
                sr.color = new Color(1 - timerHitFlash / hitFlashTime, 1 - timerHitFlash / hitFlashTime, 1 - timerHitFlash / hitFlashTime);
            }
        }
        else
        {
            timerDead -= Time.deltaTime;
            sr.color = new Color(timerDead / deadTime, timerDead / deadTime, timerDead / deadTime, timerDead / deadTime);
        }
        
    }

    private void OnDestroy()
    {
        EnemyBirthControl.Instance.CountDown();
    }
}
