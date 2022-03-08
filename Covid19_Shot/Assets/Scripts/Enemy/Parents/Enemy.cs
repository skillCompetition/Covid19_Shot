using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int speed;
    protected Rigidbody2D rigid;

    protected Player player => SystemManager.Instance.Player;

     Animator anim;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// 적군이 처음 등장하자마자 이동한다
    /// </summary>
    protected virtual void Start()
    {
        rigid.AddForce(Vector2.down * speed);
    }


    protected virtual void Update()
    {
        if (HP <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        Destroy(gameObject);
    }

    protected virtual IEnumerator Attack()
    {
        yield return null;
    }




    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet.myBullet == Bullet.BulletType.Player)
            {
                anim.SetTrigger("isHit");
                HP -=
               collision.gameObject.GetComponent<Bullet>().damage;
            }

        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            if (gameObject.name == "Boss Enemy")
                return;

            //플레이어의 고통 게이지 +
            Dead();
        }
    }
}
