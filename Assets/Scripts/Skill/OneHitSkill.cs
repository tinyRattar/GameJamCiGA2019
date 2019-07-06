using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitSkill: MonoBehaviour
{
    [SerializeField]List<GameObject> listHitedObjects = new List<GameObject>();

    public bool addNewHited(GameObject target)
    {
        if (listHitedObjects.Contains(target))
        {
            Debug.Log("hit twice more");
            return false;
        }
        else
        {
            Debug.Log("hit first time");
            listHitedObjects.Add(target);
            return true;
        }
    }
}
