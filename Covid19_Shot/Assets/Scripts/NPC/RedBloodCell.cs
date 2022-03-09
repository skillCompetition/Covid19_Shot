using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : NPC
{

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        rigid.AddForce(Vector2.up.normalized * speed,ForceMode2D.Impulse);
    }



    void Update()
    {
        
    }

    protected override void Dead()
    {
        //플레이어 고통게이지 증가
        Debug.Log("//플레이어 고통게이지 증가");


        base.Dead();

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet.myBullet == Bullet.BulletType.Enemy)//적 총알을 맞았을 때
            {
                Dead();
            }
        }
    }
}