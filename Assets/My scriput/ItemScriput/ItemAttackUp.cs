using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttackUp : Itembase
{
    float _power = 1;
    public override void Activate()
    {
        //�A�C�e���ɐڐG����ƍU���͂��オ��B
        Cane.attackpower += _power;
    }
}
