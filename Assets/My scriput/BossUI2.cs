using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI2 : MonoBehaviour
{
    [SerializeField] GameObject bossUi;
    [SerializeField] AudioSource bossBgm;
    [SerializeField] AudioClip bgmCip;
    float count = 0f;
    public bool cameraf = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && count < 1)
        {
            cameraf = true;
            count++;
            Debug.Log("zza");
            bossUi.SetActive(true);
            bossBgm.clip = bgmCip;
            bossBgm.Play();
        }
    }
}
