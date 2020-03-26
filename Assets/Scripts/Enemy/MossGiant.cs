using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }
    //Use this for initialization
    public override void Init()
    {
        base.Init();
        //Health = base.health;
    }
    public void Damage()
    {
       
    }

}
