using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Itembass : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _source;
    [SerializeField] ActivateTiming _activateTiming;
    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _source.clip = _clip;
            _source.Play();
            if(_activateTiming == ActivateTiming.get)
            {
                Activate();
                Destroy(gameObject);
            }
        }
    }
    enum ActivateTiming
    {
        get,
    }


}
