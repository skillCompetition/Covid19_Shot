using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : NPC
{
    [SerializeField] GameObject[] iTems;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        rigid.AddForce(Vector2.down.normalized * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }

    protected override void Dead()
    {
        base.Dead();
    }

    /// <summary>
    /// 아이템을 스폰
    /// </summary>
    private void SpawnItem()
    {

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet.myBullet == Bullet.BulletType.Player)
            {
                SpawnItem();
                Dead();
            }
        }
    }
}
