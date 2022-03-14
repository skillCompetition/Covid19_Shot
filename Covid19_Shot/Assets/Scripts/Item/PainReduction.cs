using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainReduction : Item
{
    [SerializeField] int decreaseAmount;

    protected override void Update()
    {
        base.Update();
    }

    protected override void Use()
    {
        player.ReductionPain(decreaseAmount);
        base.Use();
    }
}
