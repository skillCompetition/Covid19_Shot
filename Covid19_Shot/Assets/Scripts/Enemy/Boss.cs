using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    GameObject bullet;
    protected override void Awake()
    {
        base.Awake();
        bullet = Resources.Load("Bullet/Boss Bullet") as GameObject;
    }

    protected override void Start()
    {
        base.Start();
        Invoke("Stop", 2f);
        StartCoroutine("Attack");
    }

    private void Stop()
    {
        rigid.velocity = Vector2.zero;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override IEnumerator Attack()
    {
            if (HP <= 0)
                StopCoroutine("Attack");

            StartCoroutine("Barrage");
            yield return new WaitForSeconds(0.3f);
            StartCoroutine("Circle");

    }

    /// <summary>
    /// 부채형태의 연속공격
    /// </summary>
    /// <returns></returns>
    IEnumerator Barrage()
    {
        if (HP <= 0)
            yield break;
        int bulletNum = 101;

        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 10 * i / bulletNum), -1);

            bullet.GetComponent<Rigidbody2D>().AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Circle()
    {

        int bulletNum = 201;

        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bulletNum), 
                                         Mathf.Sin(Mathf.PI * 2 * i / bulletNum));

            bullet.GetComponent<Rigidbody2D>().AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
