using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] PlayerScript player;
    [SerializeField] Animator playerAnim;
    [SerializeField] Countercript counter;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(counter.counterMteki == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (counter.counterMteki == false)
                {
                    if (gameObject != null)
                    {
                        HPUI.hp -= enemyScript.enemyPower;
                        player.rb.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
                        if (HPUI.hp >= 1)
                        {
                            playerAnim.SetTrigger("ishurt");
                        }
                    }
                    if (HPUI.hp < 1)
                    {
                        playerAnim.SetTrigger("isDie");
                    }
                }
                
            }
        }
       
    }
}

