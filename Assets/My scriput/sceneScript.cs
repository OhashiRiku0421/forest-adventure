using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneScript : MonoBehaviour
{
    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource buttonAudio2;
    GameObject titleAudio;

    void Start()
    {
        titleAudio = GameObject.Find("titleaudio");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Stage2");
        }
    }
    public void ButtonAudio(int stageNo)
    {
        buttonAudio.Play();
        StartCoroutine("LoadGameScene", stageNo);
    }
   private IEnumerator LoadGameScene(int stageNo)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("manual");
    }
    public void ButtonAudio2(int stageNo)
    {
        buttonAudio.Play();
        StartCoroutine("LoadGameScene2", stageNo);
    }
    private IEnumerator LoadGameScene2(int stageNo)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(titleAudio);
        HPUI.hp = 5;
        PlayerScript.horizontalSpeed = 10;
        Cane.attackpower = 1;
        SceneManager.LoadScene("Stage‚P");
    }
    public void ButtonAudio3(int stageNo)
    {
        buttonAudio2.Play();
        StartCoroutine("LoadGameScene3", stageNo);
    }
    private IEnumerator LoadGameScene3(int stageNo)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("title");
    }

}
