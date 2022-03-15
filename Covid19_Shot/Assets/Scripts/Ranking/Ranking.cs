using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    [SerializeField] Text[] names;
    [SerializeField] Text[] scores;


    public static List<Rank>  ranking = new List<Rank>();

    void Start()
    {
        RankingSet("r", 0);
        RankingSet("rr", 12);
        RankingSet("rrr", 4);
        RankingSet("rrrr", 9);
        RankingSet("rrrrr", 90);

        ShowRanking();

    }


    public static void RankingSet(string name, int score)
    {

        Rank rank = new Rank();

        rank.name = name;
        rank.score = score;
        ranking.Add(rank);


        //람다식을 이용해서 점수 순으로 정렬
        ranking.Sort((rank1, rank2) => rank1.score.CompareTo(rank2.score));

    }


    void ShowRanking()
    {
        for (int i = 1; i <= names.Length; i++)
        {
            Debug.Log(names.Length - i);
            names[i - 1].text = ranking[names.Length - i].name;
            scores[i - 1].text = ranking[names.Length - i].score.ToString();
        }
    }
}
