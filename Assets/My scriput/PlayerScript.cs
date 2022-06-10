using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] int jumpForce;
    [SerializeField] int jumpSpeed;
    [SerializeField] CheckGround checkground;
    [SerializeField] CircleCollider2D stick;
    [SerializeField] BoxCollider2D thunder;
    [SerializeField] BoxCollider2D counter;
    [SerializeField] float interval;
    [SerializeField] float interval2;
    [SerializeField] float interval3;
    [SerializeField] float counterCollider;
    [SerializeField] Animator anime;
    [SerializeField] Animator anime2;
    [SerializeField] RocketScript rocketscript;
    [SerializeField] float godTime;
    [SerializeField] float hitTime = 0.5f;
    [SerializeField] HPUI hpUi;
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] BossScript boss;
    CapsuleCollider2D cc;
    // float damage = 1;
   // public float hp = 3f;
    public bool die = false;
    bool muteki = false;
    bool hit = false;
    public Animator anim;
    Rigidbody2D rb;
    bool ismovenow = false;
    float timer = 0f;
    float time = 0f;//経過時間
    float time2 = 0f;
    float time3 = 0f;
    float time4 = 0f;
    float hitTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //this.gameObject.SetActive(false);
        // anim.enabled = false;
    }
    void FixedUpdate()
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
            if (muteki == true)
            {
                time4 += Time.deltaTime;
                cc.enabled = false;
                if (time4 > godTime)
                {
                    muteki = false;
                    cc.enabled = true;
                    time4 = 0;
                }
            }
        }
        if (die == true)
        {
            SceneManager.LoadScene("result");
        }
        if (hit)
        {
            hitTimer += Time.deltaTime;
            if (hitTimer >= hitTime)
            {
                hitTimer = 0;
                hit = false;
            }
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
                if (checkground.GetCheckGround())
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
        if (hit == false)
        {
            if (collision.gameObject.tag == "enemy")
            {
                //Debug.Log("aaaaaa");
                hit = true;
                RocketScript rocket = collision.gameObject.GetComponent<RocketScript>();
                if (rocket != null)
                {
                    HPUI.hp -= rocket.rocketPower;
                        rb.AddForce(-Vector2.right * 10, ForceMode2D.Impulse);
                    if (enemyScript.transform.rotation.y > 0 || boss.transform.rotation.y > 0)
                    {
                        Debug.Log("vhsdhvuds");
                        rb.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
                    }
                }
                muteki = true;
                if (HPUI.hp >= 1)
                {
                    anim.SetTrigger("ishurt");
                }
            }
            if (collision.gameObject.tag == "Enemy")
            {
                //Debug.Log("aaaaaa");
                hit = true;
                if (enemyScript != null)
                {
                    HPUI.hp -= enemyScript.enemyPower;
                    rb.AddForce(-Vector2.right * 20, ForceMode2D.Impulse);
                    if (enemyScript.transform.rotation.y > 0 || boss. transform.rotation.y > 0)
                    {
                        rb.AddForce(Vector2.right * 40, ForceMode2D.Impulse);
                    }
                }
                muteki = true;
                if (HPUI.hp >= 1)
                {
                    anim.SetTrigger("ishurt");
                }
            }
            if (HPUI.hp < 1)
            {
                anim.SetTrigger("isDie");
            }
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
        Debug.Log("ssssss");
        die = true;
    }
}
