using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int speed;
    protected Rigidbody2D rigid;

    public bool isDead;

    protected Player player => SystemManager.Instance.Player;

     Animator anim;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        if (HP <= 0)
        {
            Dead();
        }
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

    public virtual void Dead()
    {
        isDead = true;
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

            if (bullet.myBullet == Bullet.BulletType.Player) //플레이어 총알에 맞았을때
            {
                anim.SetTrigger("isHit");
                HP -= bullet.damage;
            }

        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            if (gameObject.CompareTag("Boss"))
                return;

            //플레이어의 고통 게이지 +
            Dead();
        }
    }
}
