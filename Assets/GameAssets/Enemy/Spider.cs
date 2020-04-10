using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    
    public GameObject acidPrefab;
    //Use this for initialization
    public override void Update()
    {
        
    }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Damage()
    {
        base.Damage();
    }

    public override void Movement()
    {
        //Don't move
    }

    public override void Attack()
    {
        Instantiate(acidPrefab, transform.position - new Vector3(0.5f,0,0), Quaternion.identity);
    }
}
