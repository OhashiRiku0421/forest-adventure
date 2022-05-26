using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    [SerializeField] private EnemyScript enemyscript;
    private PlayerScript playerscript;
    private Animator anim;
    private Animator anime;
    private int thundercount = 0;
    public float magicpower = 3;
    void Start()
    {
        playerscript = FindObjectOfType<PlayerScript>();
        anim = playerscript.GetComponent<Animator>();//playerのアニメーション
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //サンダーのカウントが１以下の時かつLookUpのアニメーションがtrueの時以下を実行する
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp") == true && thundercount <1)
        {
            anime.SetTrigger("isThunder");
            thundercount++;
        }
        //LookUpのアニメーションがfalseの時カウントをリセットする
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("LookUp") == false)
        {
            thundercount = 0;
        }
    }
}
