using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Parce : MonoBehaviour
{
    public List<Spawn> spawnList = new List<Spawn>();


    SpawnPoints spawnPoints => SystemManager.Instance.SpawnPoints;


    void Awake()
    {
        ReadSpawnFile();

    }

    void Start()
    {
        spawnPoints.StartCoroutine(spawnPoints.SpawnEnemy(spawnList));
        Debug.Log("후");
    }

    void Update()
    {
    }

    void ReadSpawnFile()
    {
        
        spawnList.Clear();

        //TextAsset : 텍스트 파일 에셋 클래스
        TextAsset textFile = Resources.Load("Stage1") as TextAsset;
        //StringReader : 파일 내의 문자열 데이터 읽기 클래스
        StringReader stringReader = new StringReader(textFile.text);

        while(stringReader != null)
        {
            //ReadLine() = 텍스트 데이터를 한 줄 씩 반환
            string line = stringReader.ReadLine();
            Debug.Log(line);

            if (line == null)
                break;

            Spawn spawnData = new Spawn();

            spawnData.type = line.Split(',')[0];
            spawnData.point = int.Parse(line.Split(',')[1]);
            spawnData.delay = float.Parse(line.Split(',')[2]);

            spawnList.Add(spawnData);

        }


        //stringReader로 열어둔 파일은 작업 후 꼭 닫기
        stringReader.Close();

    }
}
