using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int HealthValue;

    public override void OnTaken(Collider2D collision)
    {
        base.OnTaken(collision);
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
