using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField] Image HPImg;
    [SerializeField] Image painImg;

    [SerializeField] Text HPText;
    [SerializeField] Text painText;

    float HP;
    float pain;

    Player player => SystemManager.Instance.Player;

    void Awake()
    {
        HPImg = HPImg.GetComponent<Image>();
        painImg = painImg.GetComponent<Image>();
        HPText = HPText.GetComponent<Text>();
        painText = painText.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        HP = SystemManager.Instance.Player.HP;
        pain = SystemManager.Instance.Player.pain;

        HPImg.fillAmount = HP / Player.MaxHP;
        painImg.fillAmount = pain / Player.MaxPain;

        HPText.text = player.HP.ToString();
        painText.text = player.pain.ToString();

    }
}
