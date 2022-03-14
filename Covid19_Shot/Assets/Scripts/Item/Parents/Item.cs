using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected int speed;
    protected Player player => SystemManager.Instance.Player;

    protected virtual void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

    }

    protected virtual void Use()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Use();
        }
    }
}
