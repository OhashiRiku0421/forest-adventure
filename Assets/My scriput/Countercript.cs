using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countercript : MonoBehaviour
{
    [SerializeField] Animator anime;
    [SerializeField] bool counter = true;
    [SerializeField] float emperorTime;
    [SerializeField] CapsuleCollider2D cc;
    [SerializeField] SpriteRenderer sr;
    bool _canCounter = false;
    float time = 0f;
    void Start()
    {
        counter = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(counter == false)
        {
            anime.SetTrigger("iscounterattack");
            counter = true;
        }
        if(_canCounter == true)
        {
            time += Time.deltaTime;
            cc.enabled = false;
            if(time > emperorTime)
            {
                _canCounter = false;
                cc.enabled = true;
                time = 0;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            counter = false;
            _canCounter = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            sr.enabled = false;
        }
    }
}
