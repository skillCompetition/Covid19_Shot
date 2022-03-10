using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : Item
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }

    protected override void Use()
    {
        
        player.curTime = 0;  
        player.isInvincibility = true;
        Debug.Log("½ÇÇà");
        base.Use();

    }

    



}
