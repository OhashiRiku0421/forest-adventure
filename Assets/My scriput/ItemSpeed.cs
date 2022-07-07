using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed : Itembase
{
    float _moveSpeed = 5;
    public override void Activate()
    {
        //アイテムをに接触するとスピードが上がる。
        PlayerScript.horizontalSpeed += _moveSpeed;
    }
}
