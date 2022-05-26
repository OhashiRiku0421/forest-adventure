using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float hp = 3;//hp�ݒ�
    [SerializeField] private Cane cane;
    [SerializeField] private ThunderScript thunderscript;
    private PlayerScript playerscript;

    Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��ɓ������������U�����Ă鎞�ȉ������s����
        if (collision.gameObject.tag == "stick")
        {
            Debug.Log("hit");//hit�̃��O���o��
            hp -= collision.gameObject.GetComponent<Cane>().attackpower;//Cane����Q��
        }
        
        if(collision.gameObject.tag == "thunder")
        {
           Debug.Log("hit");
           hp -= collision.gameObject.GetComponent<ThunderScript>().magicpower;
        }
        if (hp <= 0)
        {
           Destroy(gameObject);//hp��0�̎����̃I�u�W�F�N�g���폜����
        }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        playerscript = FindObjectOfType<PlayerScript>();
        //playerscript = GameObject.Find("player").GetComponent<PlayerScript>();//�v���C���[����Q��
        anim = playerscript.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
