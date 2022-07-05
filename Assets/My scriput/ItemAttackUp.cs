using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttackUp : Itembass
{
    float _power = 1;
    public override void Activate()
    {
        Cane.attackpower += _power;
    }
}
