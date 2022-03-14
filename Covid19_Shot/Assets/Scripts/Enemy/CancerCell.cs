using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerCell : Enemy
{
    GameObject bullet;

    protected override void Awake()
    {
        base.Awake();
        bullet = Resources.Load("Bullet/CancerCell Bullet") as GameObject;
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine("Attack");

    }

    protected override void Update()
    {
        base.Update();
    }

    protected override IEnumerator Attack()
    {

        for (int i = 0; i < 3;i++)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().moveVec = Vector3.down;
            
            yield return new WaitForSeconds(0.1f);

        }


    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
