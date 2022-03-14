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
    SpawnPoints spawnPoint => SystemManager.Instance.SpawnPoints;
    

    [SerializeField] GameObject spawnEnemy;


    [SerializeField] Transform[] enemySpawnPoints; 
    protected override void Awake()
    {
        base.Awake();
        bullet = Resources.Load("Bullet/Boss Bullet") as GameObject;
        HPImg = HPImg.GetComponent<Image>();
    }

    protected override void Start()
    {
        ShowBoss();
        HP = (int)MaxHP;
        Invoke("Stop", 2f);
        ChooseAttack();

    }

    void ShowBoss()
    {
        Debug.Log("멈쳐!!");
        spawnPoint.StopCoroutine(stageFlow.redCoroutine);
        spawnPoint.StopCoroutine(stageFlow.whiteCoroutine);
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


    private void ShowHPImg()
    {
        HPImg.fillAmount = HP / MaxHP;
    }

    private void Stop()
    {
        speed = 0;
    }



    public override void Dead()
    {
        Debug.Log("죽음");
        stageFlow.CheckStage(stageFlow.stage);
        stageFlow.redCoroutine = spawnPoint.StartCoroutine(spawnPoint.RedSpawn());
        stageFlow.whiteCoroutine = spawnPoint.StartCoroutine(spawnPoint.WhiteSpawn());
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
            bullet.GetComponent<Bullet>().moveVec = dirVec;
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


            bullet.GetComponent<Bullet>().moveVec = dirVec;
            bullet2.GetComponent<Bullet>().moveVec = dirVec2;

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
            Instantiate(spawnEnemy, enemySpawnPoints[0].position, enemySpawnPoints[0].rotation);
            Instantiate(spawnEnemy, enemySpawnPoints[1].position, enemySpawnPoints[1].rotation);
            yield return new WaitForSeconds(0.5f);

        }

        ChooseAttack();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
