using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public const float MaxHP = 100f;
    public const float MaxPain = 100f;
    public int HP;
    public int score;
    public int pain;

    bool isGameEnd;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1;
        HP = (int)MaxHP;
        pain = 30;

        
    }

    void Update()
    {
        if((HP <= 0  || pain >= 100 )&& !isGameEnd)
        {
            GameOver(false);
        }
    }

    public string thisGameScene;
    public void GameOver(bool isClear)
    {
        isGameEnd = true;
        SceneManager.LoadScene("EndScene");

    }

    
    public void RestartBtnCilck()
    {
        SceneManager.LoadScene(thisGameScene);
    }
}
