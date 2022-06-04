using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    [SerializeField] EnemyScript enemyscript;
    [SerializeField] float interval;
    [SerializeField] Animator enemyAnime;
    SpriteRenderer sr;
    BoxCollider2D box2d;
    public float rocketPower = 3;
    private bool _testBool = false;
    float timar = 0f;
    Animator anime;
    // Start is called before the first frame update
    void Start()
    {
       
        box2d = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyAnime.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            anime.SetBool("isRocket", false);
        }

            if (enemyscript.canEnn == true && timar > interval)
            {
                _testBool = false;
                anime.SetBool("isRocket", true);
                timar = 0;
            }
            if (_testBool || enemyscript.canEnn == false)
            {
                anime.SetBool("isRocket", false);
            }
        timar += Time.deltaTime;
    }
    void RocketInterval()
    {
        _testBool = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "counter")
        {
            sr.enabled = false;
            box2d.enabled = false;

        }
    }
    
       
    
    private void SpriteActive() 
    {
        sr.enabled = true;
        box2d.enabled = true;
    }
}
