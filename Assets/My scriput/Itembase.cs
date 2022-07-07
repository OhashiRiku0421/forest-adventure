using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e���̊��N���X
public abstract class Itembase : MonoBehaviour
{
    //�I�[�f�B�I�N���b�v : �A�C�e�����擾�����Ƃ��ɖ炷��
    [SerializeField] AudioClip _clip;
    //�I�[�f�B�I�\�[�X
    [SerializeField] AudioSource _source;

    /// <summary> �A�C�e������肵�����̏��� </summary>
    public abstract void Activate();
    //abstract�Ƃ� �I�[�o�[���C�h����������B
    //virtual�Ƃ� �I�[�o�[���C�h�\�ɂ���B(�I�[�o�[���C�h���Ȃ��Ă��悢�B)

    //�A�C�e���ɐG�ꂽ���̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[�ɐG�ꂽ�ꍇ
        if (collision.gameObject.tag == "Player")
        {
            //����炷
            _source.clip = _clip;
            _source.Play();
            //�A�C�e���̎擾����
            Activate();
            //���g(���̃A�C�e�����g)��j��
            Destroy(gameObject);
        }
    }
}
