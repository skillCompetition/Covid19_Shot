using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    GameObject bullet;
    [SerializeField] Image HPImg;

    [SerializeField] const float MaxHP = 100f;


    StageFlow stageFlow => SystemManager.Instance.StageFlow;

    [SerializeField] GameObject spawnEnemy;


    [SerializeField] Transform[] spawnPoints; 
    protected override void Awake()
    {
        base.Awake();
        bullet = Resources.Load("Bullet/Boss Bullet") as GameObject;
        HPImg = HPImg.GetComponent<Image>();
    }

    protected override void Start()
    {
        HP = (int)MaxHP;
        rigid.AddForce(Vector2.down.normalized * speed);
        Invoke("Stop", 2f);
        ChooseAttack();
    }

    protected override void Update()
    {
        if (HP <= 0)
        {
            StopAllCoroutines();
        }
        base.Update();

        ShowHPImg();
    }

    public void ShowBoss()
    {
        gameObject.SetActive(true);
    }

    private void ShowHPImg()
    {
        HPImg.fillAmount = HP / MaxHP;
    }

    private void Stop()
    {
        rigid.velocity = Vector2.zero;
    }



    public override void Dead()
    {
        stageFlow.CheckStage(stageFlow.stage);
        base.Dead();
    }



    int attackPattern = 0;      //어떤 공격을 할지 정하는 인덱스

    /// <summary>
    /// 어떤 공격을 할지 정할 수 있음
    /// </summary>
    void ChooseAttack()
    {


        if (attackPattern >= 3)
            attackPattern = 0;

        switch (attackPattern) 
        {
            case 0: StartCoroutine(Barrage());
                break;
            case 1: StartCoroutine(Circle());
                break;
            case 2: StartCoroutine(SpawnEnemy());
                break;
            default:
                break;
        }

        attackPattern++;
    }


    /// <summary>
    /// 부채형태의 연속공격
    /// </summary>
    /// <returns></returns>
    IEnumerator Barrage()
    {
        if (HP <= 0)
            yield break;
        int bulletNum = 101;

        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 10 * i / bulletNum), -1);
            bullet.GetComponent<Rigidbody2D>().AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);
        }
        ChooseAttack();
    }

    /// <summary>
    /// 원형태의 공격
    /// </summary>
    /// <returns></returns>
    IEnumerator Circle()
    {
        if (HP <= 0)
            yield break;

        int bulletNum = 201;

        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
            GameObject bullet2 = Instantiate(this.bullet, transform.position, transform.rotation);

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bulletNum), 
                                         Mathf.Sin(Mathf.PI * 2 * i / bulletNum));
            Vector2 dirVec2 = new Vector2(Mathf.Sin(Mathf.PI * 2 * i / bulletNum),
                                          Mathf.Cos(Mathf.PI * 2 * i / bulletNum));
                            

            bullet.GetComponent<Rigidbody2D>().AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);
            bullet2.GetComponent<Rigidbody2D>().AddForce(dirVec2.normalized * 10, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);
        }

        ChooseAttack();

    }

    /// <summary>
    /// 작은 적군들 소환
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemy()
    {
        if (HP <= 0)
            yield break;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(spawnEnemy, spawnPoints[0].position, spawnPoints[0].rotation);
            Instantiate(spawnEnemy, spawnPoints[1].position, spawnPoints[1].rotation);
            yield return new WaitForSeconds(0.5f);

        }

        ChooseAttack();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
