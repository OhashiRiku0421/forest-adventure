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
    [SerializeField] float enemySpeed = 10;
    // [SerializeField] BoxCollider2D b2;
    // [SerializeField] BoxCollider2D enn2;
    [SerializeField] Animator thunderAnime;
    [SerializeField] Animator windAnime;
    [SerializeField] float enemyTime;
    [SerializeField] Countercript counter;
    [SerializeField] BoxCollider2D attack;
    [SerializeField] BoxCollider2D attack2;
    [SerializeField] float mutekidayo;
    [SerializeField] GameObject tama;
    [SerializeField] Transform muzzle;
    [SerializeField] Transform muzzle2;
    [SerializeField] AudioSource enemyAudio;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioSource enemyAudio2;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioSource enemyAudio3;
    [SerializeField] AudioClip clip3;
    float kaminari = 0f;
    public bool canBullrt = false;
    float mutekicount = 0f;
    float mutekitime = 0f;
    float timer = 0f;
   public SpriteRenderer sr;
    public int enemyPower;
    float enemyCount = 0f;
    Rigidbody2D rb2d;
     PlayerScript playerscript;
    Animator enemyAnime;
   public bool canEnn = false;
    public bool canEnn2 = false;
    Animator anim;
    int randomAttack;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        playerscript = FindObjectOfType<PlayerScript>();
        //playerscript = GameObject.Find("player").GetComponent<PlayerScript>();//プレイヤーから参照
        anim = playerscript.GetComponent<Animator>();
        enemyAnime = GetComponent<Animator>();
        canEnn = false;
    }
    private void FixedUpdate()
    {
        if(!enemyAnime.GetCurrentAnimatorStateInfo(0).IsName("spiderhut") && canEnn2)
        {
            Vector2 targeting = (player.transform.position - transform.position).normalized;
            rb2d.velocity = new Vector2((targeting.x * 5), 0);
            Debug.Log(targeting.x);
            if (targeting.x > 0)
            {
                sr.flipX = false;
                enemyAnime.SetBool("isWalk", true);
            }
            else
            {
                sr.flipX = true;
                enemyAnime.SetBool("isWalk", true);
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
            hp -= Cane.attackpower;//Caneから参照
            if (sr.flipX == true)
            {
                rb2d.AddForce(transform.right * 4000);
            }
            if (sr.flipX == false)
            {
                rb2d.AddForce(-transform.right * 4000);
            }
                enemyAnime.SetTrigger("isHit");
        }
        if(collision.gameObject.tag == "thunder" && kaminari < 1)
        {
            kaminari++;
           Debug.Log("hit2");
           hp -= collision.gameObject.GetComponent<ThunderScript>().magicpower;
            enemyAnime.SetTrigger("isHit");
            if (sr.flipX == true)
            {
                rb2d.AddForce(transform.right * 4000);
            }
            if (sr.flipX == false)
            {
                rb2d.AddForce(-transform.right * 4000);
            }
        }
        if (collision.gameObject.tag == "wind" && enemyCount < 1)
        {
            enemyCount++;
            Debug.Log("hit3");
            hp -= collision.gameObject.GetComponent<WindScript>().windPower;
            enemyAnime.SetTrigger("isHit");
            if (sr.flipX == true)
            {
                rb2d.AddForce(transform.right * 5000);
            }
            if (sr.flipX == false)
            {
                rb2d.AddForce(-transform.right * 5000);
            }
        }
        if (hp <= 0)
        {
            enemyAnime.SetTrigger("isDie");
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enn")
        {
            canEnn = true;
        }
        if(collision.gameObject.tag == "enn2")
        {
            canEnn2 = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enn")
        {
            canEnn = false;
        }
        if(collision.gameObject.tag == "enn2")
        {
            canEnn2 = false;
        }
    }
    void Update()
    {
        if(windAnime.GetCurrentAnimatorStateInfo(0).IsName("Wind") == false)
        {
            enemyCount = 0;
        }
        if(thunderAnime.GetCurrentAnimatorStateInfo(0).IsName("thunder") == false)
        {
            kaminari = 0;
        }
        if(canEnn == true && timer >= enemyTime)
        {
            randomAttack = Random.Range(0, 2);
            if(randomAttack == 0)
            {
                enemyAnime.SetTrigger("isAttack");
            }
            if(randomAttack == 1)
            {
                enemyAnime.SetTrigger("isAttack2");
            }
            timer = 0;
        }
        IsCount();
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(counter.counterMteki == false)
        {
            if (collision.gameObject.tag == "Player" && mutekicount <= 0)
            {
                if (counter.counterMteki == false)
                {
                    mutekicount++;
                    if (gameObject != null)
                    {
                        //Debug.Log("qqq");
                        HPUI.hp -= enemyPower;
                        if (sr.flipX == true)
                        {
                            //  Debug.Log("aa");
                            playerscript.rb.AddForce(-Vector2.right * 20, ForceMode2D.Impulse);
                        }
                        if (sr.flipX == false)
                        {
                            //  Debug.Log("ii");
                            playerscript.rb.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
                        }
                        if (HPUI.hp >= 1)
                        {
                            anim.SetTrigger("ishurt");
                        }
                    }
                    if (HPUI.hp < 1)
                    {
                        // Debug.Log("zzzz");
                        anim.SetTrigger("isDie");
                    }
                }
            }
        }
    }
    void IsCount()
    {
        
        if (mutekicount >= 1)
        {
            mutekitime += Time.deltaTime;
            if (mutekitime >= mutekidayo)
            {
                Debug.Log("zaza");
                mutekicount = 0;
            }
        }
    }
    void EnemyAttackTrue()
    {
        if(sr.flipX == false)
        {
            attack.enabled = true;
        }
        if(sr.flipX)
        {
            attack2.enabled = true;
        }
    }
    void EnemyAttackFalse()
    {
        attack.enabled = false;
        attack2.enabled = false;
    }
    void Bullet()
    {
        GameObject bullet = Instantiate(tama);
        if (sr.flipX)
        {
            canBullrt = true;
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.rotation = muzzle.transform.rotation;
        }
        else if(!sr.flipX)
        {
            bullet.transform.position = muzzle2.transform.position;
            bullet.transform.rotation = muzzle2.transform.rotation;
        }
    }
    void EnemyHit()
    {
        enemyAudio.clip = clip1;
        enemyAudio.Play();
    }
    void EnemyAttackAudio()
    {
        enemyAudio2.clip = clip2;
        enemyAudio2.Play();
    }
    void EnemyAttackAudio2()
    {
        enemyAudio3.clip = clip3;
        enemyAudio3.Play();
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
