using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlow : MonoBehaviour
{
    SpawnDataReader spawnDataReader =>
        SystemManager.Instance.SpawnDataReader;

    SpawnPoints spawnPoints =>
        SystemManager.Instance.SpawnPoints;

    GameManager gameManager =>
        SystemManager.Instance.GameManager;

    public Coroutine redCoroutine;
    public Coroutine whiteCoroutine;

    List<Spawn> spawnList = new List<Spawn>();


    public int stage = 1;


    void Start()
    {
        CheckStage(stage);

        redCoroutine = spawnPoints.StartCoroutine(spawnPoints.RedSpawn());
        whiteCoroutine = spawnPoints.StartCoroutine(spawnPoints.WhiteSpawn());
    }

    public void CheckStage(int stage)
    {
        switch (stage)
        {
            case 1:
                spawnList = spawnDataReader.ReadSpawnFile("stage1");
                spawnPoints.StartCoroutine(spawnPoints.SpawnEnemy(spawnList));
                this.stage++;
                break;
            case 2:
                spawnList = spawnDataReader.ReadSpawnFile("stage2");
                spawnPoints.StartCoroutine(spawnPoints.SpawnEnemy(spawnList));
                this.stage++;
                break;

            case 3:
                //∞‘¿” ≥°
                gameManager.GameOver();
                break;
            default:
                break;
        }
    }

}
