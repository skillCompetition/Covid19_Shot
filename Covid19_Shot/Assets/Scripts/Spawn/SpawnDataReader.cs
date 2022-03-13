using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnDataReader : MonoBehaviour
{
    public List<Spawn> spawnList = new List<Spawn>();
    public string stageName;
 
    SpawnPoints spawnPoints => SystemManager.Instance.SpawnPoints;


    void Awake()
    {
        //ReadSpawnFile(stageName);

    }

    void Start()
    {
        //spawnPoints.StartCoroutine(spawnPoints.SpawnEnemy(spawnList));
    }




    public List<Spawn> ReadSpawnFile(string stageName)
    {
        
        spawnList.Clear();

        //TextAsset : 텍스트 파일 에셋 클래스
        TextAsset textFile = Resources.Load(stageName) as TextAsset;
        //StringReader : 파일 내의 문자열 데이터 읽기 클래스
        StringReader stringReader = new StringReader(textFile.text);

        while(stringReader != null)
        {
            //ReadLine() = 텍스트 데이터를 한 줄 씩 반환
            string line = stringReader.ReadLine();

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

        return spawnList;
    }
}
