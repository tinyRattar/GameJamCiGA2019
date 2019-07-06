using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillManager : MonoBehaviour
{
    List<UISkill> listUISkill;

    public void StartSkillCD(int index,float cdTime)
    {
        listUISkill[index].StartCD(cdTime);
    }

    public void SetSkillNum(int index, int num)
    {
        listUISkill[index].SetNum(num);
    }

    // Start is called before the first frame update
    void Awake()
    {
        listUISkill = new List<UISkill>(this.GetComponentsInChildren<UISkill>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
