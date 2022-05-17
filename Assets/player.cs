using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private  Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private int jumpForce;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private CheckGround checkground;

    bool ismovenow = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalkey = Input.GetAxisRaw("Horizontal");
        //�E���͂ŉE�����ɓ���
        if(horizontalkey > 0)
        {
           ismovenow = true;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
            anim.SetBool("isRun", true);
        }
        //�����͂ō������ɓ���
        else if(horizontalkey < 0)
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
    void Update()
    {
        Jump();
        // rb.velocity = new Vector2(Input.GetAxis("Horizontal") * jumpSpeed, rb.velocity.y);
    }
    void Jump()
    {
        bool jumpKey = Input.GetButtonDown("Jump");
        //�W�����v�̌v�Z
        if (jumpKey)
        {
            if (checkground.GetCheckGround())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("isJump", true);
            }
        } 
    }
    public void Land()
    {
        anim.SetBool("isJump", false);
    }
}
