using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Use()
    {

        base.Use();

        if (player.bulletLevel >= 4)
            return;

        player.bulletLevel++;


    }

}
