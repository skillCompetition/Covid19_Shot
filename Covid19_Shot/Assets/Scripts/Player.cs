using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    public const float MaxHP = 100f;
    public const float MaxPain = 100f;
    public int HP;
    public int score;
    public int pain = 30;       //고통
    public int bulletLevel;
    public bool isInvincibility = false;        //플레이어의 무적상태


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
    }

    public float curTime;

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("move", (int)moveX);

        curTime += Time.deltaTime;
        Debug.Log(curTime);

        if (curTime >= 3f)
        {
            if (isInvincibility)
                isInvincibility = false;
            curTime = 0;
        }
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

    void OnFire()
    {


        GameObject bullet = Instantiate(bullets[bulletLevel], transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up.normalized * speed, ForceMode2D.Impulse);
    }

    public void RecoverHP(int recoverAmount)
    {
        HP += recoverAmount;
        if (HP >= 100)
            HP = 100;
    }

    public void ReductionPain(int descreaseAmount)
    {
        pain -= descreaseAmount;
        if (pain <= 0)
            pain = 0;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincibility)
            return;

        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if(bullet.myBullet == Bullet.BulletType.Enemy)
                HP -= bullet.damage;
            Debug.Log("공격!");
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //플레이어 HP 감소 => 몬스터의 공격력의 절반


            Destroy(collision.gameObject);
        }
    }
}
