using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    //0 : B
    //1 : C
    //2 : G
    //3 : V
    [Header("Enemy")]
    public GameObject[] enemyType;
    [SerializeField] Transform[] enemySpawnPos;

    [Header("Boss")]
    [SerializeField] GameObject boss;
    [SerializeField] Transform bossPos;

    [Header("NPC")]
    [SerializeField] GameObject red;
    [SerializeField] float redCycle;
    [SerializeField] int redper;
    [SerializeField] Transform[] redSpawnPos;
    [SerializeField] GameObject white;
    [SerializeField] float whiteCycle;
    [SerializeField] int whiteper;
    [SerializeField] Transform[] whiteSpawnPos;

    [Header("Item")]
    [SerializeField] GameObject[] items;

    public Transform whiteTrans;

    public float ranSpawnTime;


    public IEnumerator SpawnEnemy(List<Spawn> spawnList)
    {

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

             Instantiate(enemy, enemySpawnPos[spawnList[i].point].position, enemySpawnPos[spawnList[i].point].rotation);

            yield return new WaitForSeconds(spawnList[i].delay);
        }

        yield return new WaitForSeconds(5f);
        
        Instantiate(boss, bossPos.position, bossPos.rotation);
    }
    

    public void SpawnItem(Transform transform)
    {
        Quaternion rotation = Quaternion.Euler(0,0,90);

        Instantiate(items[Random.Range(0, items.Length)],transform.position, rotation);
    }

    public IEnumerator RedSpawn()
    {

        for (; ; )
        {
            if (Random.Range(0, redper) == 0)
            {
                Instantiate(red, redSpawnPos[Random.Range(0, whiteSpawnPos.Length)]);
            }
            else
                yield return null;

            yield return new WaitForSeconds(redCycle);
        }

    }


    
    public IEnumerator WhiteSpawn()
    {
        for (; ; )
        {

            if (Random.Range(0, whiteper) == 0)
                Instantiate(white, whiteSpawnPos[Random.Range(0, whiteSpawnPos.Length)]);
            else
                yield return null;

            yield return new WaitForSeconds(whiteCycle);
        }
    }
}
