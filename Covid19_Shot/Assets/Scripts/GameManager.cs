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

    List<Rank> ranking = new List<Rank>(5);

     

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Text scoreText;

    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        HP = (int)MaxHP;
        pain = 30;

        
    }

    void Update()
    {
        if(HP <= 0  || pain >= 100)
        {
            GameOver();
        }
    }

    public string thisGameScene;
    public void GameOver()
    {
        thisGameScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }

    public void RestartBtnCilck()
    {
        SceneManager.LoadScene(thisGameScene);
    }
}
