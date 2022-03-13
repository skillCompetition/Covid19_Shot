using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : Item
{
    Coroutine InvincibilityCoroutine = null;
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

        if (InvincibilityCoroutine != null)
        { 
            StopCoroutine(player.ShowInvincibilityChane(3f,2.5f));
            InvincibilityCoroutine = null;
        }

        InvincibilityCoroutine = player.StartCoroutine(player.ShowInvincibilityChane(3f, 2.5f));
        base.Use();

    }

    



}
