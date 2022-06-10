using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneScript : MonoBehaviour
{

   void Start()
    {
        Invoke("ChangeScene", 1f);
    }
  public void ButtonClick()
    {
        HPUI.hp = 5;
        SceneManager.LoadScene("Stage‚P");
    }
    public void ButtonClick2()
    {
        SceneManager.LoadScene("title");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Stage2");
        }
    }

}
