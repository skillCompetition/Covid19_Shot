using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    protected Rigidbody2D rigid;
    [SerializeField] protected float speed;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Dead();
        }

    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
}
