using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    public GameObject[] enemyType;
    [SerializeField] GameObject[] items;
    public Transform whiteTrans;

    public float ranSpawnTime;


    void Start()
    {
        //StartCoroutine(SpawnRedBloodCell());
    }

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
                case "R":
                    enemy = enemyType[4];
                    break;
                case "W":
                    enemy = enemyType[5];
                    break;

                default:
                    break;
            }

            Instantiate(enemy, spawnPoint[spawnList[i].point].position, spawnPoint[spawnList[i].point].rotation);

            yield return new WaitForSeconds(spawnList[i].delay);
        }

    }

    void EndSpawn()
    {
        SystemManager.Instance.Boss.ShowBoss();
    }
    

    public void SpawnItem(Transform transform)
    {
        Quaternion rotation = Quaternion.Euler(0,0,90);

        Instantiate(items[Random.Range(0, items.Length)],transform.position, rotation);
    }
}
