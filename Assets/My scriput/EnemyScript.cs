using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float hp = 3;//hp設定
    [SerializeField] private Cane cane;
    [SerializeField] private ThunderScript thunderscript;
    private PlayerScript playerscript;

    Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //杖に当たった時かつ攻撃してる時以下を実行する
        if (collision.gameObject.tag == "stick")
        {
            Debug.Log("hit");//hitのログを出す
            hp -= collision.gameObject.GetComponent<Cane>().attackpower;//Caneから参照
        }
        
        if(collision.gameObject.tag == "thunder")
        {
           Debug.Log("hit");
           hp -= collision.gameObject.GetComponent<ThunderScript>().magicpower;
        }
        if (hp <= 0)
        {
           Destroy(gameObject);//hpが0の時このオブジェクトを削除する
        }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        playerscript = FindObjectOfType<PlayerScript>();
        //playerscript = GameObject.Find("player").GetComponent<PlayerScript>();//プレイヤーから参照
        anim = playerscript.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
