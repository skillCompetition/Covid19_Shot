using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    [SerializeField] Text[] names;
    [SerializeField] Text[] scores;

    int score;
    string ID;
    [SerializeField] InputField input;
    [SerializeField] GameObject panel;

    public List<Rank>  ranking = new List<Rank>();

    void Start()
    {
        //score = SystemManager.Instance.GameManager.score

        SetRanking();

    }


    public void RankingSet(string name, int score)
    {

        Rank rank = new Rank();

        rank.name = name;
        rank.score = score;
        ranking.Add(rank);


        //람다식을 이용해서 점수 순으로 정렬
        ranking.Sort((rank1, rank2) => rank1.score.CompareTo(rank2.score));

        ShowRanking();
    }


    public void ShowRanking()
    {
        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log(ranking[0].name);

            names[i].text = ranking[names.Length - i - 1].name;
            scores[i].text = ranking[names.Length - i - 1].score.ToString();
        }
    }

    void SetRanking()
    {
        ID = input.text;
        Debug.Log(ID);
    }

    public void Test(string text)
    {
        Debug.Log("Text : " + text);
    }

    public void InputBtnClick()
    {
        panel.SetActive(false);
        RankingSet(ID, score);
    }
}
