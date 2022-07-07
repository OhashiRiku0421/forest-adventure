using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeal : Itembase
{
    float _hp = 1;
    public override void Activate()
    {
        if(HPUI.hp <= 4)
        {
            HPUI.hp += _hp;
        }
    }
}
