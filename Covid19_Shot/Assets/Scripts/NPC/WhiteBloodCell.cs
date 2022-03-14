using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class WhiteBloodCell : NPC
{

    protected override void Awake() 
    {
        base.Awake();
    }

    void Start()
    {

    }


    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    protected override void Dead()
    {
        base.Dead();
    }

    /// <summary>
    /// 아이템을 스폰
    /// </summary>
    private void SpawnItemCheck()
    {
        SystemManager.Instance.SpawnPoints.SpawnItem(gameObject.transform);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet.myBullet == Bullet.BulletType.Player)
            {
                SpawnItemCheck();
                
                Dead();
            }
        }
    }
}
