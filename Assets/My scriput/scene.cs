using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    GameObject playBgm;
    // Start is called before the first frame update
    void Start()
    {
        playBgm = GameObject.Find("playBGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HPUI.hp = 5;
            Destroy(playBgm);
            SceneManager.LoadScene("stage3");
        }
    }
}
