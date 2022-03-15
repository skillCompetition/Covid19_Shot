using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance = null;
    

    public static SystemManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [SerializeField]
    Player player;
    public Player Player
    {
        get
        {
            return player; 
        }
    }

    [SerializeField]
    GameManager gameManager;
    public GameManager GameManager
    {
        get
        {
            return gameManager;
        }
    }

    [SerializeField]
    SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints
    {
        get
        {
            return spawnPoints;
        }
    }


    [SerializeField]
    SpawnDataReader spawnDataReader;
    public SpawnDataReader SpawnDataReader
    {
        get
        {
            return spawnDataReader;
        }
    }

    [SerializeField]
    StageFlow stageFlow;
    public StageFlow StageFlow
    {
        get
        {
            return stageFlow;
        }
    }

} 
