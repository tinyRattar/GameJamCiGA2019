using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectBox : MonoBehaviour
{
    [SerializeField] int attackValue = 10;
    [SerializeField] ElementType elementType = ElementType.None;

    bool isWork = true;
    OneHitSkill skill;

    public void Init(int attack, ElementType type, OneHitSkill iSkill = null)
    {
        attackValue = attack;
        elementType = type;
        if (iSkill != null)
            skill = iSkill;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (skill == null)
            skill = this.GetComponentInParent<OneHitSkill>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnHit()
    {
        //todo: hit effect
        //Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isWork)
        {
            if (skill.addNewHited(collision.gameObject))
            {
                if (collision.GetComponent<Enemy>().OnHit(attackValue, elementType))
                {
                    OnHit();
                }
            } 
        }
    }
}
