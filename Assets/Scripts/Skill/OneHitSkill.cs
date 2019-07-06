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
            return false;
        }
        else
        {
            listHitedObjects.Add(target);
            return true;
        }
    }
}
