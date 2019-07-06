using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirthControl : MonoBehaviour
{
    public static EnemyBirthControl Instance;
    public bool hasRest = true;
    int curCount = 0;
    [SerializeField] int maxCount;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More Than two instance");
        }
    }

    public void CountUp()
    {
        curCount++;
        if (curCount >= maxCount)
            hasRest = false;
    }

    public void CountDown()
    {
        curCount--;
        if (curCount < maxCount)
            hasRest = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
