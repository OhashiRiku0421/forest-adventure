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
    [SerializeField] AudioSource counterAudio;
    [SerializeField] AudioClip counterCip;
    public bool _canCounter = false;
    float time = 0f;
    public bool counterMteki = false;
    void Start()
    {
        counter = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(counter == false)
        {
            counterAudio.clip = counterCip;
            counterAudio.Play();
            anime.SetTrigger("iscounterattack");
            counter = true;
        }
        if(_canCounter == true)
        {
            time += Time.deltaTime;
            cc.enabled = false;
            if(time > emperorTime)
            {
                counterMteki = false;
                _canCounter = false;
                cc.enabled = true;
                time = 0;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet" || collision.gameObject.tag == "slash" || collision.gameObject.tag == "boss")
        {
            counterMteki = true;
                counter = false;
                _canCounter = true;
        }
    }
}
