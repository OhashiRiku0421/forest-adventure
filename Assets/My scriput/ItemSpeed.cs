using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed : Itembase
{
    float _moveSpeed = 5;
    public override void Activate()
    {
        //�A�C�e�����ɐڐG����ƃX�s�[�h���オ��B
        PlayerScript.horizontalSpeed += _moveSpeed;
    }
}
