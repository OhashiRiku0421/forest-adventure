using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]  float hp = 3;//hp設定
    [SerializeField]  Cane cane;
    [SerializeField]  ThunderScript thunderscript;
    [SerializeField] WindScript windScript;
    [SerializeField] GameObject player;
    [SerializeField] float enemySpeed;
    [SerializeField] int enemySpeed2;
    [SerializeField] BoxCollider2D b2;
    Rigidbody2D rb2d;
     PlayerScript playerscript;
    Animator enemyAnime;
   public bool canEnn = false;

    Animator anim;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerscript = FindObjectOfType<PlayerScript>();
        //playerscript = GameObject.Find("player").GetComponent<PlayerScript>();//プレイヤーから参照
        anim = playerscript.GetComponent<Animator>();
        enemyAnime = GetComponent<Animator>();
        canEnn = false;
    }
    private void FixedUpdate()
    {
        if(!enemyAnime.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            Vector2 targeting = (player.transform.position - transform.position).normalized;
            rb2d.velocity = new Vector2((targeting.x * 2) * enemySpeed, 0);
            if (targeting.x > 0)
            {
                transform.rotation = new Quaternion(0, 1f, 0, 0);
                enemyAnime.SetBool("isRun", true);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                enemyAnime.SetBool("isRun", true);
            }

            if (canEnn == true)
            {
                enemySpeed = 1.5f;
            }
            else
            {
                enemySpeed = 2;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //杖に当たった時かつ攻撃してる時以下を実行する
        if (collision.gameObject.tag == "stick")
        {
            Debug.Log("hit1");//hitのログを出す
            hp -= collision.gameObject.GetComponent<Cane>().attackpower;//Caneから参照
            enemyAnime.SetTrigger("ishit");
        }
        
        if(collision.gameObject.tag == "thunder")
        {
           Debug.Log("hit2");
           hp -= collision.gameObject.GetComponent<ThunderScript>().magicpower;
            enemyAnime.SetTrigger("ishit");
        }
        if (collision.gameObject.tag == "wind")
        {
            Debug.Log("hit3");
            hp -= collision.gameObject.GetComponent<WindScript>().windPower;
            enemyAnime.SetTrigger("ishit");
        }
        if (hp <= 0)
        {
           Destroy(gameObject);//hpが0の時このオブジェクトを削除する
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enn")
        {
            canEnn = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enn")
        {
            canEnn = false;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "wind")
    //    {
    //        Debug.Log("hit3");
    //        hp -= collision.gameObject.GetComponent<WindScript>().windPower;
    //        enemyAnime.SetTrigger("ishit");
    //    }
    //}
    void Update()
    {
    }
}
