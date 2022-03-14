using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int speed;

    public Vector3 moveVec;

    public enum BulletType
    {
        Player,
        Enemy
    }

    public BulletType myBullet;

    void Update()
    {
        switch (myBullet)
        {
            case BulletType.Player:
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                break;
            case BulletType.Enemy:
                transform.Translate(moveVec * speed * Time.deltaTime);

                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss")) && myBullet == BulletType.Player)
        {
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.CompareTag("Player") && myBullet == BulletType.Enemy)
        {
            Destroy(gameObject);
        }
    }



}
