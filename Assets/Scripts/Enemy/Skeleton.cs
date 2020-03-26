using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    //Use this for initialization
    public override void Init()
    {
        base.Init();
        //assign heath prop to  enemy health
    }

    public void Damage()
    {
        Debug.Log("DAMAGE!!!!");
        //subtract 1 from health

        //if health < 1
            //destroy bject
    }
}
