﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MossGiant : Enemy, IDamageable
{
    //public override int Health { get; set; }
    
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();
    }
    public override void Damage()
    {
        base.Damage();
    }

}
