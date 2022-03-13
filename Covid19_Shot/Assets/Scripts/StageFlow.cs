using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlow : MonoBehaviour
{
    SpawnDataReader spawnDataReader =>
        SystemManager.Instance.SpawnDataReader;

    SpawnPoints spawnPoints =>
        SystemManager.Instance.SpawnPoints;

    List<Spawn> spawnList = new List<Spawn>();


    public int stage = 1;

    private void Awake()
    {
    }

    void Start()
    {
        CheckStage(stage);


    }

    public void CheckStage(int stage)
    {
        switch (stage)
        {
            case 1:
                spawnList = spawnDataReader.ReadSpawnFile("stage1");
                spawnPoints.StartCoroutine(spawnPoints.SpawnEnemy(spawnList));
                stage++;
                break;
            case 2:
                spawnList = spawnDataReader.ReadSpawnFile("stage2");
                spawnPoints.StartCoroutine(spawnPoints.SpawnEnemy(spawnList));
                stage++;
                break;

            case 3:
                //∞‘¿” ≥°
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
