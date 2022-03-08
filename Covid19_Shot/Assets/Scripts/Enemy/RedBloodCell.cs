using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : Enemy
{
    public int painDamage;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        rigid.AddForce(Vector2.up * speed);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }



}
