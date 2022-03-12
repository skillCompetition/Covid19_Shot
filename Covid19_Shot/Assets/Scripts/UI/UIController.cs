using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [Header("Gauge")]
    [SerializeField] Image HPImg;
    [SerializeField] Image painImg;
    [SerializeField] Text HPText;
    [SerializeField] Text painText;
    float HP;
    float pain;

    [Header("Score")]
    [SerializeField] Text scoreText;

    GameManager gameManager => SystemManager.Instance.GameManager;

    void Awake()
    {
        HPImg = HPImg.GetComponent<Image>();
        painImg = painImg.GetComponent<Image>();
        HPText = HPText.GetComponent<Text>();
        painText = painText.GetComponent<Text>();
        scoreText = scoreText.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        HP = gameManager.HP;
        pain = gameManager.pain;

        HPImg.fillAmount = HP / GameManager.MaxHP;
        painImg.fillAmount = pain / GameManager.MaxPain;

        HPText.text = gameManager.HP.ToString();
        painText.text = gameManager.pain.ToString();

        scoreText.text =  "score : "  + gameManager.score.ToString();

    }
}
