using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{

    [SerializeField] int recoverAmount;     //È¸º¹·®

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Use()
    {
        player.HP += recoverAmount;
        base.Use();
    }

}
