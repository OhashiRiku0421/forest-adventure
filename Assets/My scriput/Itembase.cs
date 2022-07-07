using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの基底クラス
public abstract class Itembase : MonoBehaviour
{
    //オーディオクリップ : アイテムを取得したときに鳴らす音
    [SerializeField] AudioClip _clip;
    //オーディオソース
    [SerializeField] AudioSource _source;

    /// <summary> アイテムを入手した時の処理 </summary>
    public abstract void Activate();
    //abstractとは オーバーライドを強制する。
    //virtualとは オーバーライド可能にする。(オーバーライドしなくてもよい。)

    //アイテムに触れた時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーに触れた場合
        if (collision.gameObject.tag == "Player")
        {
            //音を鳴らす
            _source.clip = _clip;
            _source.Play();
            //アイテムの取得処理
            Activate();
            //自身(このアイテム自身)を破棄
            Destroy(gameObject);
        }
    }
}
