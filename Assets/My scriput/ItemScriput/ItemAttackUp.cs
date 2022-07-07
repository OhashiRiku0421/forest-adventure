using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttackUp : Itembase
{
    float _power = 1;
    public override void Activate()
    {
        //アイテムに接触すると攻撃力が上がる。
        Cane.attackpower += _power;
    }
}
