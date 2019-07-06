using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int healthValue;

    public override void OnTaken(Collider2D collision)
    {
        base.OnTaken(collision);
        Player_Control.Instance.player_health += healthValue;
        BloodCTRL.bloodChange = healthValue;
        BloodCTRL.flag_add = true;
        //todo: health up
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
