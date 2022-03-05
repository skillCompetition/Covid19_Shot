using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : Enemy
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }



    public override void Dead()
    {
        base.Dead();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
