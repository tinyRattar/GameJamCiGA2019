using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponManager : MonoBehaviour
{
    public static UIWeaponManager Instance;
    [SerializeField] List<UIWeapon> listUIWeapon;
    [SerializeField] List<Transform> listPosMask;
    [SerializeField] List<Vector3> listPos;
    int main = 0;
    int right = 1;
    int left = 2;

    public void SwitchLeft()
    {
        listUIWeapon[main].StartSwitch(listPos[2], false);
        listUIWeapon[right].StartSwitch(listPos[0], true);
        listUIWeapon[left].StartSwitch(listPos[1], false);
        int oldMain = main;
        main = right;
        right = left;
        left = oldMain;
    }

    public void SwitchRight()
    {
        listUIWeapon[main].StartSwitch(listPos[1], false);
        listUIWeapon[left].StartSwitch(listPos[0], true);
        listUIWeapon[right].StartSwitch(listPos[2], false);
        int oldMain = main;
        main = left;
        left = right;
        right = oldMain;
    }

    // Start is called before the first frame update
    void Awake()
    {
        listUIWeapon = new List<UIWeapon>(this.GetComponentsInChildren<UIWeapon>());
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More Than two instance");
        }
    }

    private void Start()
    {
        listPos = new List<Vector3>();
        for (int i = 0; i < listPosMask.Count; i++)
        {
            listPos.Add(listPosMask[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
