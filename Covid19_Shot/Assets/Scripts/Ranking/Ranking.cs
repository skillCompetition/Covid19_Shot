using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    List<Rank> ranking = new List<Rank>();

    void Start()
    {
        RankingSet("r",0);
        RankingSet("r",12);
        RankingSet("r",4);
        RankingSet("r",9);
        RankingSet("r",90);

        Check();
    }


    public void RankingSet(string name, int score)
    {
        Rank rank = new Rank();

        rank.name = name;
        rank.score = score;
        ranking.Add(rank);


        //람다식을 이용해서 점수 순으로 정렬
        ranking.Sort((rank1, rank2) => rank1.score.CompareTo(rank2.score));
        
    }

    void Check()
    {
        for (int i = 0; i < ranking.Count; i++)
        {
            Debug.Log(ranking[i].score);
        }
    }
}
