using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private int jumpForce;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private CheckGround checkground;
    [SerializeField] private CircleCollider2D stick;
    [SerializeField] private BoxCollider2D thunder;
    private Animator anim;
    private  Rigidbody2D rb;
    bool ismovenow = false;
    private float interval;
    private float interval2;
    private float time = 0f;//�o�ߎ���
    private float time2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        interval = 0.7f;//���ԊԊu
        interval2 = 2f;

        //this.gameObject.SetActive(false);
        // anim.enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {  
        //attack��false�̎��ȉ�������
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp"))
        {
            //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp"));

             float horizontalkey = Input.GetAxisRaw("Horizontal");
            //�E���͂ŉE�����ɓ���
            if (horizontalkey > 0)
            {
                ismovenow = true;
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
                anim.SetBool("isRun", true);
            }
            //�����͂ō������ɓ���
            else if (horizontalkey < 0)
            {
                ismovenow = true;
                transform.rotation = new Quaternion(0, 180f, 0, 0); //�����͂ō������ɔ��]
                rb.velocity = new Vector2(-horizontalSpeed, rb.velocity.y);
                anim.SetBool("isRun", true);
            }
            //�{�^���𗣂��Ǝ~�܂�
            else if (ismovenow)
            {
                ismovenow = false;
                rb.velocity = Vector2.zero;
                anim.SetBool("isRun", false);
            }
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > interval)//�}�E�X�����N���b�N������
        {
            //���N���b�N���͂�attack����
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("attack");
                time = 0;//���ԃ��Z�b�g
            }
        }
        Jump();
        IsLookUp();
    }
    void Jump()
    {
        bool jumpKey = Input.GetButtonDown("Jump");
       
        if (jumpKey)
        {
            if (checkground.GetCheckGround())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //�W�����v�̌v�Z
                anim.SetBool("isJump", true);
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
    public void Land()
    {
        anim.SetBool("isJump", false);
    }
    private void IsAttackFalse()//���O�ύX
    {
        //�A�j���[�V�����C�x���g�ŌĂяo��
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
}