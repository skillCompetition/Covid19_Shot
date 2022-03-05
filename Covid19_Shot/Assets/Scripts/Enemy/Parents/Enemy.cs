using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int speed;
    Rigidbody2D rigid;


    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    protected virtual void Start()
    {
        rigid.AddForce(Vector2.down * speed);
    }

    public virtual void Dead()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //플레이어의 고통 게이지 +

            //오브젝트 삭제
        }
    }
    
}
