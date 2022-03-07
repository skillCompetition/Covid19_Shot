using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grem : Enemy
{
    GameObject bullet;

    protected override void Awake()
    {
        base.Awake();
        bullet = Resources.Load("Bullet/Grem Bullet") as GameObject;
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


    /// <summary>
    /// 공격하는 코루틴
    /// </summary>
    /// <returns></returns>
    protected override IEnumerator Attack()
    {
        for (int i = 0;i < 3 ;i++ )
        { 

            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);
        }

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

}
