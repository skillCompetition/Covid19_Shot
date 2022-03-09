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
            Vector3 dirVec = player.transform.position - transform.position;
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(dirVec.normalized, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);

        }


    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
