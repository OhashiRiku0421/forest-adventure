using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static float horizontalSpeed = 10;
    [SerializeField] int jumpForce;
    [SerializeField] int jumpSpeed;
    [SerializeField] CheckGround checkGround;
    [SerializeField] CircleCollider2D stick;
    [SerializeField] BoxCollider2D thunder;
    [SerializeField] BoxCollider2D counter;
    [SerializeField] float interval;
    [SerializeField] float interval2;
    [SerializeField] float interval3;
    [SerializeField] float counterCollider;
    [SerializeField] Animator anime;
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] BossScript boss;
    [SerializeField] GameObject bossEnemy;
    [SerializeField] Countercript cs;
    public bool die = false;
    public Animator anim;
    public Rigidbody2D rb;
    bool ismovenow = false;
    float timer = 0f;
    float time = 0f;//経過時間
    float time2 = 0f;
    float time3 = 0f;
    GameObject playBgm;

    void Start()
    {
        playBgm = GameObject.Find("playBGM");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //this.gameObject.SetActive(false);
    }   
    public void FixedUpdate()
    {
        //attackがfalseの時以下が動く
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp"))
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("counter") && !anim.GetCurrentAnimatorStateInfo(0).IsName("counterattack"))
                {
                    if (!anime.GetCurrentAnimatorStateInfo(0).IsName("Wind") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
                    {
                        float horizontalkey = Input.GetAxisRaw("Horizontal");
                        //右入力で右向きに動く
                        if (horizontalkey > 0)
                        {
                            ismovenow = true;
                            transform.rotation = new Quaternion(0, 0, 0, 0);
                            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
                            anim.SetBool("isRun", true);
                        }
                        //左入力で左向きに動く
                        else if (horizontalkey < 0)
                        {
                            ismovenow = true;
                            transform.rotation = new Quaternion(0, 180f, 0, 0); //左入力で左向きに反転
                            rb.velocity = new Vector2(-horizontalSpeed, rb.velocity.y);
                            anim.SetBool("isRun", true);
                        }
                        //ボタンを離すと止まる
                        else if (ismovenow)
                        {
                            ismovenow = false;
                            rb.velocity = Vector2.zero;
                            anim.SetBool("isRun", false);
                        }
                    }
                }
            }
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > interval)//マウスを左クリックした時
        {
            //左クリック入力でattackする
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("attack");
                time = 0;//時間リセット
            }
        }
        if (die == true)
        {
            Destroy(playBgm);
            SceneManager.LoadScene("result");
        }
        Jump();
        IsLookUp();
        IsCounter();
    }
    void Jump()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            bool jumpKey = Input.GetButtonDown("Jump");
            if (jumpKey)
            {
                if (checkGround.GetCheckGround())
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //ジャンプの計算
                    anim.SetBool("isJump", true);
                }
            }
        }
    }
    public void IsLookUp()
    {
        time2 += Time.deltaTime;
        if (time2 > interval2)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetTrigger("isLookUp");
                time2 = 0;
            }
        }
    }
    public void IsCounter()
    {
        time3 += Time.deltaTime;
        if (time3 > interval3)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                counter.enabled = true;
                anim.SetTrigger("iscounter");
                time3 = 0;
            }
        }
        if (counter.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer > counterCollider)
            {
                counter.enabled = false;
                timer = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(cs.counterMteki == false)
        {
            if (collision.gameObject.tag == "bullet")
            {
                if (cs.counterMteki == false)
                {
                    if (gameObject != null)
                    {
                        //Debug.Log("qqq");
                        HPUI.hp -= enemyScript.enemyPower;
                        if (enemyScript.canBullrt == true)
                        {
                            rb.AddForce(-Vector2.right * 10, ForceMode2D.Impulse);
                            enemyScript.canBullrt = false;
                        }
                        else
                        {
                            rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                        }
                        if (HPUI.hp >= 1)
                        {
                            anim.SetTrigger("ishurt");
                        }
                    }
                }
                   
            }
            if (collision.gameObject.tag == "slash")
            {
                if (cs.counterMteki == false)
                {
                    HPUI.hp -= boss.bossPower;
                    if (bossEnemy.transform.rotation.y == 0)
                    {
                        rb.AddForce(-Vector2.right * 10, ForceMode2D.Impulse);
                    }
                    else if (bossEnemy.transform.rotation.y >= 1)
                    {
                        rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                    }
                    if (HPUI.hp >= 1)
                    {
                        anim.SetTrigger("ishurt");
                    }
                }
            }
            if (collision.gameObject.tag == "boss")
            {
                if (cs.counterMteki == false)
                {
                    HPUI.hp -= boss.bossPower;
                    if (bossEnemy.transform.rotation.y == 0)
                    {
                        rb.AddForce(-Vector2.right * 20, ForceMode2D.Impulse);
                    }
                    else if (bossEnemy.transform.rotation.y >= 1)
                    {
                        rb.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
                    }
                    if (HPUI.hp >= 1)
                    {
                        anim.SetTrigger("ishurt");
                    }
                }     
            }
        }
        if (HPUI.hp < 1)
        {
          // Debug.Log("zzzz");
         anim.SetTrigger("isDie");
        }
    }
    public void Land()
    {
        anim.SetBool("isJump", false);
    }
    private void IsAttackFalse()//名前変更
    {
        //アニメーションイベントで呼び出す
        stick.enabled = false;
    }
    private void ColiderSet()
    {
        stick.enabled = true;
    }
    private void IsThunderFalse()
    {
        thunder.enabled = false;
    }
    private void ColiderSet2()
    {
        thunder.enabled = true;
    }
    public void IsDie()
    {
        die = true;
    }
}
