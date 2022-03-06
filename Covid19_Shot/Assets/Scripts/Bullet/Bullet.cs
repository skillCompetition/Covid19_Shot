using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public enum BulletType
    {
        Player,
        Enemy
    }

    public BulletType myBullet;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy" && myBullet == BulletType.Player)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player" && myBullet == BulletType.Enemy)
        {
            Destroy(gameObject);
        }
    }



}
