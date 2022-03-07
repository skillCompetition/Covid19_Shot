using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameObject[] enemyType;

    public float ranSpawnTime;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
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
