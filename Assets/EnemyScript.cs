using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float hp = 3;//hp設定
    [SerializeField] private Cane cane;
    private PlayerScript playerscript;
   public bool flg = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerscript = GameObject.Find("player").GetComponent<PlayerScript>();//プレイヤーから参照
            if (! flg && collision.gameObject.tag == "stick" && playerscript.isAttack == true)//杖に当たった時かつ攻撃してる時以下を実行する
            {
                Debug.Log("hit");//hitのログを出す
                hp -= collision.gameObject.GetComponent<Cane>().attackpower;//Caneから参照
                playerscript.isAttack = false;
            }
            if (hp <= 0)
            {
                Destroy(gameObject);//hpが0の時このオブジェクトを削除する
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
