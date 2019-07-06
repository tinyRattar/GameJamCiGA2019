using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health;
    GameObject target;
    Vector2 defaultMoveDirection;
    float defaultMoveSpeedScale = 1.0f;
    float totalDropItemProp = 0;

    [SerializeField] ElementType elementType;
    [SerializeField] int maxHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] float randomDirectionResetTime = 2.0f;

    [SerializeField] List<GameObject> dropItemList;
    [SerializeField] List<float> dropItemPropList;
    float timerRDRT = 0;

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
        DropRandomItem();
        Destroy(this.gameObject, 1.0f);
    }

    public void OnHit(int value, ElementType type = ElementType.None)
    {
        float effect = Util.CalcElementEffect(type, elementType);
        health += (int)(effect * value);
        //todo : onhit
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
    }





    // Start is called before the first frame update
    void Start()
    {
        foreach (float prop in dropItemPropList)
        {
            totalDropItemProp += prop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DefaultMove();
        if (KillIt)
        {
            KillIt = false;
            OnKill();
        }
    }
}
