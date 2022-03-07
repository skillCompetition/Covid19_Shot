using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint;

    [SerializeField] Dictionary<string, GameObject> enemies = new Dictionary<string, GameObject>();

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        int RanPoint = Random.Range(0, spawnPoint.Length);
        yield return null;
    }
}
