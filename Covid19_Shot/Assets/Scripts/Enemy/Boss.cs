using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        Invoke("Stop", 2f);
    }

    private void Stop()
    {
        rigid.velocity = Vector2.zero;
        Debug.Log("»Ð");
    }

    protected override void Update()
    {
        base.Update();
    }

    /*protected override IEnumerator Attack()
    {

    }*/

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
