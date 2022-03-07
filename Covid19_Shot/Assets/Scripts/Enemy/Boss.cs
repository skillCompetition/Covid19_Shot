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
        StartCoroutine("Barrage");


        yield return null;
    }

    IEnumerator Barrage()
    {
        int bulletNum = 101;

        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
            Debug.Log("bullet : " + bullet.transform.position);

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bulletNum), -1);

            bullet.GetComponent<Rigidbody2D>().AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }
    

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
