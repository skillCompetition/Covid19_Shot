using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject[] bullets;
    public int bulletLevel;
    public bool isInvincibility = false;        //플레이어의 무적상태

    SpriteRenderer sprite;

    private float moveX;
    private float moveY;

    GameManager gameManager => SystemManager.Instance.GameManager;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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
        transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        curTime += Time.deltaTime;

    }

    

    void FixedUpdate()
    {

    }

    void OnMove(InputValue inputValue)
    {
        Vector2 moveMentVector = inputValue.Get<Vector2>();
        moveX = moveMentVector.x;
        moveY = moveMentVector.y;

    }

    GameObject bullet;
    void OnFire()
    {
        bullet = Instantiate(bullets[bulletLevel], transform.position, transform.rotation);
    }

   

    public void RecoverHP(int recoverAmount)
    {
        gameManager.HP += recoverAmount;
        if (gameManager.HP >= 100)
            gameManager.HP = 100;
    }

    public void ReductionPain(int descreaseAmount)
    {
        gameManager.pain -= descreaseAmount;
        if (gameManager.pain <= 0)
            gameManager.pain = 0;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincibility)
            return;

        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if(bullet.myBullet == Bullet.BulletType.Enemy)
                gameManager.HP -= bullet.damage;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //플레이어 HP 감소 => 몬스터의 공격력의 절반

            Destroy(collision.gameObject);

            StartCoroutine(ShowInvincibilityChane(1.5f,1.5f));

        }
    }


    public IEnumerator ShowInvincibilityChane(float realTime,float showTime)
    {

        isInvincibility = true;
        sprite.color = new Color(1, 1, 1, 0.7f);

        yield return new WaitForSeconds(showTime);

        sprite.color = Color.white;

        yield return new WaitForSeconds(realTime);

        isInvincibility = false;


    }
}
