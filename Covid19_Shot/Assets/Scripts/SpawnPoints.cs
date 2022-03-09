using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    public GameObject[] enemyType;

    public float ranSpawnTime;

    void Start()
    {
        //StartCoroutine(SpawnEnemy());
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
}
