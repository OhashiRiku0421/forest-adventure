using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float hp = 3;//hp�ݒ�
    [SerializeField] private Cane cane;
    private PlayerScript playerscript;
   public bool flg = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerscript = GameObject.Find("player").GetComponent<PlayerScript>();//�v���C���[����Q��
            if (! flg && collision.gameObject.tag == "stick" && playerscript.isAttack == true)//��ɓ������������U�����Ă鎞�ȉ������s����
            {
                Debug.Log("hit");//hit�̃��O���o��
                hp -= collision.gameObject.GetComponent<Cane>().attackpower;//Cane����Q��
                playerscript.isAttack = false;
            }
            if (hp <= 0)
            {
                Destroy(gameObject);//hp��0�̎����̃I�u�W�F�N�g���폜����
            }
    }
  
    // Start is called before the first frame update
    void Start()
    {  
    }
    // Update is called once per frame
    void Update()
    {
    }
}
