using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{
    [SerializeField] Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        //scoreTxt.text = "score: " + SystemManager.Instance.GameManager.score.ToString();
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGameBtn()
    {
        SceneManager.LoadScene("EndScene");

    }
}
