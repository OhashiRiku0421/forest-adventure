using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    [SerializeField] Animator anime;
    SpriteRenderer sR;
    Animator windAnim;
    int windCount = 0;
    public float windPower = 3;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        windAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anime.GetCurrentAnimatorStateInfo(0).IsName("counterattack") == true && windCount < 1)
        {
            windAnim.SetTrigger("isWind");
            windCount++;
        }
        else if(anime.GetCurrentAnimatorStateInfo(0).IsName("counterattack") == false)
        {
            windCount = 0;
        }
    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Enemy")
    //    {
    //        sR.enabled = false;
    //    }
    //}
    void IsSpriteTrue()
    {
        sR.enabled = true;
    }
}
