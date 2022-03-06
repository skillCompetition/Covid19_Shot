using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    public int HP;
    public int bulletLevel;
    public int painLevel;       //고통게이지

    private float moveX;
    private float moveY;

    [SerializeField] GameObject[] bullets;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("move", (int)moveX);
    }


    void FixedUpdate()
    {
        transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 moveMentVector = inputValue.Get<Vector2>();
        moveX = moveMentVector.x;
        moveY = moveMentVector.y;

    }

    IEnumerator Fire()
    {
        for (; ; )
        {
            GameObject bullet =  Instantiate(bullets[bulletLevel], transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            HP -= bullet.damage;
        }
    }
}
