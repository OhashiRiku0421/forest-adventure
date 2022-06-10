using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D enn;
    [SerializeField] float interval;
    [SerializeField] float bossSpeed;
    [SerializeField] GameObject player;
    [SerializeField] BoxCollider2D box2d;
    [SerializeField] Cane cane;
    [SerializeField] ThunderScript thunderscript;
    [SerializeField] WindScript windScript;
    [SerializeField] float hp;
    [SerializeField] Animator wind;
    float bossCount = 0;
    Rigidbody2D rb2d;
    float timar = 0f;
    Animator bossAnim;
    bool attackInterval = false;
    bool _enn = false;

    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!bossAnim.GetCurrentAnimatorStateInfo(0).IsName("hurt") && !bossAnim.GetCurrentAnimatorStateInfo(0).IsName("death"))
        {
            Vector2 targeting = (player.transform.position - transform.position).normalized;
            rb2d.velocity = new Vector2((targeting.x * 2) * bossSpeed, 0);
            if (targeting.x > 0)
            {
                // Debug.Log("adsfcdfcs");
                transform.rotation = new Quaternion(0, 1f, 0, 0);
                bossAnim.SetBool("isWalk", true);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                bossAnim.SetBool("isWalk", true);
            }

            if (_enn == true)
            {
                bossSpeed = 1.5f;
            }
            else
            {
                bossSpeed = 2;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_enn == true && timar > interval)
        {
            attackInterval = false;
            bossAnim.SetBool("isAttack", true);
            timar = 0;
        }
        if (attackInterval == true || _enn == false)
        {
            bossAnim.SetBool("isAttack", false);
        }
        if (wind.GetCurrentAnimatorStateInfo(0).IsName("Wind") == false)
        {
            bossCount = 0;
        }
        timar += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enn")
        {
            _enn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enn")
        {
            _enn = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //杖に当たった時かつ攻撃してる時以下を実行する
        if (collision.gameObject.tag == "stick")
        {
            Debug.Log("hit1");//hitのログを出す
            hp -= collision.gameObject.GetComponent<Cane>().attackpower;//Caneから参照
            rb2d.AddForce(transform.right * 1000);
            if (hp >= 1)
            {
                bossAnim.SetTrigger("ishurt");
            }
        }

        if (collision.gameObject.tag == "thunder")
        {
            Debug.Log("hit2");
            hp -= collision.gameObject.GetComponent<ThunderScript>().magicpower;
            rb2d.AddForce(transform.right * 1500);
            if (hp >= 1)
            {
                bossAnim.SetTrigger("ishurt");
            }
        }
        if (collision.gameObject.tag == "wind" && bossCount < 1)
        {
            bossCount++;
            Debug.Log("hit3");
            hp -= collision.gameObject.GetComponent<WindScript>().windPower;
            rb2d.AddForce(transform.right * 1000);
            if (hp >= 1)
            {
                bossAnim.SetTrigger("ishurt");
            }
        }

        if (hp < 1)
        {
            bossAnim.SetTrigger("isDeath");
        }
    }
    void AttackInterval()
    {
        attackInterval = true;
    }
    void AttackCollider()
    {
        box2d.enabled = true;
    }
    void AttackColliderFalse()
    {
        box2d.enabled = false;
    }
    void Clear()
    {
        SceneManager.LoadScene("clear");
    }
}
