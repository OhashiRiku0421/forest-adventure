using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    [SerializeField] private EnemyScript enemyscript;
    private PlayerScript playerscript;
    private Animator anim;
    private Animator anime;
    private int thundercount = 0;
    public float magicpower = 3;
    void Start()
    {
        playerscript = FindObjectOfType<PlayerScript>();
        anim = playerscript.GetComponent<Animator>();//player�̃A�j���[�V����
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�T���_�[�̃J�E���g���P�ȉ��̎�����LookUp�̃A�j���[�V������true�̎��ȉ������s����
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp") == true && thundercount <1)
        {
            anime.SetTrigger("isThunder");
            thundercount++;
        }
        //LookUp�̃A�j���[�V������false�̎��J�E���g�����Z�b�g����
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp") == false)
        {
            thundercount = 0;
        }
    }
}
