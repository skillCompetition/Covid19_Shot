using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public const float MaxHP = 100f;
    public const float MaxPain = 100f;
    public int HP;
    public int score;
    public int pain;



    void Awake()
    {
        Screen.SetResolution(1920,1080,true);
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = (int)MaxHP;
        pain = 30;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
