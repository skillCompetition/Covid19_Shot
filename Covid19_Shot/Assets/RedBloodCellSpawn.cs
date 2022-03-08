using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCellSpawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject redBloodCell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRedBloodCell()
    {
        Instantiate(redBloodCell, spawnPoints[Random.Range(0, spawnPoints.Length)].position, spawnPoints[Random.Range(0, spawnPoints.Length)].rotation);
        yield return new WaitForSeconds(0.2f);
    }
}
