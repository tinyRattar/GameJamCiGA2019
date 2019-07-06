using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] float generateIntervalTime = 1.0f;
    float timerGenerate = 0f;
    float totalEnemyProp = 0;

    [SerializeField] List<GameObject> enemyList;
    [SerializeField] List<float> enemyPropList;
    void OnGenerate()
    {
        //todo: effect
    }

    void GenerateRandomEnemy()
    {
        float r = Random.Range(0, totalEnemyProp);
        for (int index = 0; index < enemyList.Count; index++)
        {
            if (enemyPropList[index] >= r)
            {
                if (enemyList[index] != null)
                {
                    OnGenerate();
                    GameObject.Instantiate(enemyList[index], this.transform.position, new Quaternion());
                }
                break;
            }
            r -= enemyPropList[index];
        }
    }

    void DefaultGenerateBehaviour()
    {
        if (EnemyBirthControl.Instance.hasRest)
        {
            if (timerGenerate <= 0)
            {
                GenerateRandomEnemy();
                timerGenerate = generateIntervalTime;
            }
            else
            {
                timerGenerate -= Time.deltaTime;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (float prop in enemyPropList)
        {
            totalEnemyProp += prop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DefaultGenerateBehaviour();
    }
}
