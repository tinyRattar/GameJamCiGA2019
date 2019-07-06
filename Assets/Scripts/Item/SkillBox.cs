using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Blast = 0,
    Wave = 1,
    Laser = 2
}

public class SkillBox : Item
{
    [SerializeField] SkillType skillType;

    public override void OnTaken(Collider2D collision)
    {
        base.OnTaken(collision);
        Player_Control.Instance.AddSkillNum((int)skillType, 1);
        //todo: add skill
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
