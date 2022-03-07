using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField] Image HPImg;
    [SerializeField] Image painImg;

    float HP;
    float pain;

    void Awake()
    {
        HPImg = HPImg.GetComponent<Image>();
        painImg = painImg.GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        HP = SystemManager.Instance.Player.HP;
        pain = SystemManager.Instance.Player.pain;

        HPImg.fillAmount = HP / Player.MaxHP;
        painImg.fillAmount = pain / Player.MaxPain;
    }
}
