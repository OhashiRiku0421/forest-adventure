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
    [SerializeField] PlayerScript playerS;
    [SerializeField] Animator playeranim;
    [SerializeField] EnemyScript enemyS;
    [SerializeField] float mutekiInterval;
    [SerializeField] GameObject slash;
    [SerializeField] Transform bossMuzzle;
    [SerializeField] BoxCollider2D bossAttack;
    [SerializeField] BossUI boss;
    [SerializeField] AudioSource bossAudio;
    [SerializeField] AudioClip bossCip;
    [SerializeField] AudioSource bossAudio2;
    [SerializeField] AudioClip bossCip2;
    [SerializeField] AudioSource bossAudio3;
    [SerializeField] AudioClip bossCip3;
    [SerializeField] AudioSource bossAudio4;
    [SerializeField] AudioClip bossCip4;
    [SerializeField] AudioSource bossAudio5;
    [SerializeField] AudioClip bossCip5;
    [SerializeField] Animator thunderAnime;
    [SerializeField] Countercript counter;
    float kaminari = 0f;
    // [SerializeField] 
    public int bossPower;
    float mutekiTimer = 0f;
    float muteki = 0;
    float bossCount = 0;
    Rigidbody2D rb2d;
    float timar = 0f;
    Animator bossAnim;
    bool attackInterval = false;
    bool _enn = false;
    bool _enn2 = false;
    int randomAnime;

    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!bossAnim.GetCurrentAnimatorStateInfo(0).IsName("hurt") && !bossAnim.GetCurrentAnimatorStateInfo(0).IsName("death") && _enn2)
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
                bossSpeed = 2.3f;
            }
            else
            {
                bossSpeed = 3;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_enn == true && timar > interval && !bossAnim.GetCurrentAnimatorStateInfo(0).IsName("death"))
        {
            attackInterval = false;
            // bossAnim.SetBool("isAttack", true);
            randomAnime = Random.Range(0, 4);
            if(randomAnime == 0)
            {
                bossAnim.SetTrigger("isAttack");
            }
            if(randomAnime == 1)
            {
                bossAnim.SetTrigger("isAttack2");
            }
            if(randomAnime == 2)
            {
                bossAnim.SetTrigger("isBossAttack");
            }
            if (randomAnime == 3)
            {
                bossAnim.SetTrigger("isBossAttack");
            }

            timar = 0;
        }
        if (attackInterval == true || _enn == false)
        {
            //bossAnim.SetBool("isAttack", false);
        }
        if (wind.GetCurrentAnimatorStateInfo(0).IsName("Wind") == false)
        {
            bossCount = 0;
        }
        if(thunderAnime.GetCurrentAnimatorStateInfo(0).IsName("thunder") == false)
        {
            kaminari = 0;
        }
        IsCount();
        timar += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enn")
        {
            _enn = true;
        }
        if (collision.gameObject.tag == "enn2")
        {
            _enn2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enn")
        {
            _enn = false;
        }
        if (collision.gameObject.tag == "enn2")
        {
            _enn2 = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //杖に当たった時かつ攻撃してる時以下を実行する
        if (collision.gameObject.tag == "stick")
        {
            Debug.Log("hit1");//hitのログを出す
            boss.hp -= collision.gameObject.GetComponent<Cane>().attackpower;//Caneから参照
            rb2d.AddForce(transform.right * 1000);
            if (boss.hp >= 1)
            {
                bossAnim.SetTrigger("ishurt");
            }
        }

        if (collision.gameObject.tag == "thunder" && kaminari < 1)
        {
            kaminari++;
            Debug.Log("hit2");
            boss.hp -= collision.gameObject.GetComponent<ThunderScript>().magicpower;
            rb2d.AddForce(transform.right * 1500);
            if (boss.hp >= 1)
            {
                bossAnim.SetTrigger("ishurt");
            }
        }
        if (collision.gameObject.tag == "wind" && bossCount < 1)
        {
            bossCount++;
            Debug.Log("hit3");
            boss.hp -= collision.gameObject.GetComponent<WindScript>().windPower;
            rb2d.AddForce(transform.right * 1000);
            if (boss.hp >= 1)
            {
                bossAnim.SetTrigger("ishurt");
            }
        }

        if (boss.hp < 1)
        {
            bossAnim.SetTrigger("isDeath");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(counter.counterMteki == false)
        {
            if (collision.gameObject.tag == "Player" && muteki <= 0)
            {
                muteki++;
                if (gameObject != null)
                {
                    //Debug.Log("qqq");
                    HPUI.hp -= bossPower;
                    if (transform.rotation.y == 0)
                    {
                        Debug.Log("aa");
                        playerS.rb.AddForce(-Vector2.right * 20, ForceMode2D.Impulse);
                    }
                    else if (transform.rotation.y >= 1)
                    {
                        Debug.Log("ii");
                        playerS.rb.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
                    }
                    if (HPUI.hp >= 1)
                    {
                        playeranim.SetTrigger("ishurt");
                    }

                }
                if (HPUI.hp < 1)
                {
                    // Debug.Log("zzzz");
                    playeranim.SetTrigger("isDie");
                }
            }
        }
    }
    void IsCount()
    {
        if (muteki >= 1)
        {
            mutekiTimer += Time.deltaTime;
            if (mutekiTimer >= mutekiInterval)
            {
                muteki = 0;
            }
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
    void Attack2Collider()
    {
        bossAttack.enabled = true;
    }
    void Attack2ColliderFalse()
    {
        bossAttack.enabled = false;
    }
    void Clear()
    {
        SceneManager.LoadScene("clear");
    }
    void Slash()
    {
        GameObject bossAttack = Instantiate(slash);
        bossAttack.transform.position = bossMuzzle.transform.position;
        bossAttack.transform.rotation = bossMuzzle.transform.rotation;
    }
    void BossAudio()
    {
        bossAudio.clip = bossCip;
        bossAudio.Play();
    }
    void BossAudio2()
    {
        bossAudio2.clip = bossCip2;
        bossAudio2.Play();
    }
    void BossAudio3()
    {
        bossAudio3.clip = bossCip3;
        bossAudio3.Play();
    }
    void BossAudio4()
    {
        bossAudio4.clip = bossCip4;
        bossAudio4.Play();
    }
    void BossAudio5()
    {
        bossAudio5.clip = bossCip5;
        bossAudio5.Play();
    }
}
