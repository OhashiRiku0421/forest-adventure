using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneScript : MonoBehaviour
{
   void Start()
    {
        Invoke("ChangeScene", 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
