using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlow : MonoBehaviour
{
    SpawnDataReader spawnDataReader =>
        SystemManager.Instance.SpawnDataReader;

    SpawnPoints spawnPoints =>
        SystemManager.Instance.SpawnPoints;


    List<Spawn> spawnList1 = new List<Spawn>();
    List<Spawn> spawnList2 = new List<Spawn>();

    private void Awake()
    {
    }

    void Start()
    {
        spawnList1 = spawnDataReader.ReadSpawnFile("stage1");
        spawnList1 = spawnDataReader.ReadSpawnFile("stage2");

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
