using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainReduction : Item
{
    [SerializeField] int decreaseAmount;

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
        player.ReductionPain(decreaseAmount);
        base.Use();
    }
}
