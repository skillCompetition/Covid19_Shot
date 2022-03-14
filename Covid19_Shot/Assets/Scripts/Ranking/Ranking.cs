using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    List<Rank> ranking = new List<Rank>();

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RankingSet(string name, int score)
    {
        Rank rank = new Rank();

        rank.name = name;
        rank.score = score;

        for (int i = 0; i < ranking.Count; i++)
        {
            if(rank.score >= ranking[i].score)
            {
                Rank temp = new Rank();
                temp = rank;
                ranking[i] = temp;
            }
        }

        ranking.Add(rank);
    }
}
