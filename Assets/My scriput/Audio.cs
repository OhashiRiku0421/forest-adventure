using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource audio1;
    [SerializeField] AudioSource audio2;
    [SerializeField] AudioSource audio3;
    //[SerializeField] AudioSource audio4;
    [SerializeField] AudioSource audio5;
    [SerializeField] AudioClip cip1;
    [SerializeField] AudioClip cip2;
    [SerializeField] AudioClip cip3;
    //[SerializeField] AudioClip cip4;
    [SerializeField] AudioClip cip5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AttackAudio()
    {
        audio1.clip = cip1;
        audio1.Play();
    }
    void ThunderAudio()
    {
        audio2.clip = cip2;
        audio2.Play();
    }
    void WindAudio()
    {
        audio3.clip = cip3;
        audio3.Play();
    }
    void HItAudio()
    {
        audio5.clip = cip5;
        audio5.Play();
    }
}
