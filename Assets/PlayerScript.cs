using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private  Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private int jumpForce;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private CheckGround checkground;
    public bool isAttack;
    bool ismovenow = false;
    private float interval;
    private float time = 0f;//�o�ߎ���
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        interval = 0.5f;//���ԊԊu

        //this.gameObject.SetActive(false);
       // anim.enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalkey = Input.GetAxisRaw("Horizontal");
        //attack��false�̎��ȉ�������
        if (!isAttack)
        {
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
                anim.SetBool("attack", true);
                isAttack = true;

                time = 0;//���ԃ��Z�b�g
            }
        }
        Jump();
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
    public void Land()
    {
        anim.SetBool("isJump", false);
    }
    private void IsAttackFalse() 
    {
        //�A�j���[�V�����C�x���g�ŌĂяo��
        isAttack = false;
    }

}
