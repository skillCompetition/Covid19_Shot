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

    public IEnumerator SpawnEnemy(List<Spawn> spawnList)
    {

        /* for (; ; )
         {
             int ranPoint = Random.Range(0, spawnPoint.Length);
             int ranEnemy = Random.Range(0, enemyType.Length);

             Instantiate(enemyType[ranEnemy], spawnPoint[ranPoint].position, spawnPoint[ranPoint].rotation);

             yield return new WaitForSeconds(ranSpawnTime);
         }*/

        Debug.Log("¾Ö¿ë");
        GameObject enemy = null;

        
        for (int i = 0; i < spawnList.Count; i++)
        {
            switch (spawnList[i].type)
            {
                case "B":
                    enemy = enemyType[0];
                    break;
                case "C":
                    enemy = enemyType[1];
                    break;
                case "G":
                    enemy = enemyType[2];
                    break;
                case "V":
                    enemy = enemyType[3];
                    break;

                default:
                    break;
            }

            Instantiate(enemy, spawnPoint[spawnList[i].point].position, spawnPoint[spawnList[i].point].rotation);

            yield return new WaitForSeconds(spawnList[i].delay);
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
