using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    public GameObject[] enemyType;
    [SerializeField] Transform[] redSpawn;
    public GameObject redBloodCell;
    [SerializeField] GameObject[] items;
    public Transform whiteTrans;

    public float ranSpawnTime;


    void Start()
    {
        //StartCoroutine(SpawnEnemy());
        //StartCoroutine(SpawnRedBloodCell());

    }

    IEnumerator SpawnEnemy()
    {
        for (; ; )
        {
            int ranPoint = Random.Range(0, spawnPoint.Length);
            int ranEnemy = Random.Range(0, enemyType.Length);

            Instantiate(enemyType[ranEnemy], spawnPoint[ranPoint].position, spawnPoint[ranPoint].rotation);

            yield return new WaitForSeconds(ranSpawnTime);
        }
        
    }

    IEnumerator SpawnRedBloodCell()
    {
        for (; ; )
        {
            int ranRedPoint = Random.Range(0, redSpawn.Length);

            Instantiate(redBloodCell, redSpawn[ranRedPoint].position, redSpawn[ranRedPoint].rotation);

            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnItem(Transform transform)
    {
        Quaternion rotation = Quaternion.Euler(0,0,90);

        Instantiate(items[Random.Range(0, items.Length)],transform.position, rotation);
    }
}
