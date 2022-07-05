using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed : Itembass
{
    float _moveSpeed = 5;
    public override void Activate()
    {
        PlayerScript.horizontalSpeed += _moveSpeed;
    }
}
