using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] GameObject hp1;
    [SerializeField] GameObject hp2;
    [SerializeField] GameObject hp3;
    [SerializeField] GameObject hp4;
    [SerializeField] GameObject hp5;
    [SerializeField] GameObject hp6;
    [SerializeField] GameObject hp7;
    [SerializeField] GameObject hp8;
    [SerializeField] GameObject hp9;
    [SerializeField] GameObject hp10;
    [SerializeField] GameObject hp11;
    [SerializeField] GameObject hp12;
    [SerializeField] GameObject hp13;
    [SerializeField] GameObject hp14;
    [SerializeField] GameObject hp15;
    [SerializeField] GameObject hp16;
    [SerializeField] GameObject hp17;
    [SerializeField] GameObject hp18;
    [SerializeField] GameObject hp19;
    [SerializeField] GameObject hp20;
   public float hp = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 19)
        {
            Destroy(hp1);
        }
        if (hp <= 18)
        {
            Destroy(hp2);
        }
        if (hp <= 17)
        {
            Destroy(hp3);
        }
        if (hp <= 16)
        {
            Destroy(hp4);
        }
        if (hp <= 15)
        {
            Destroy(hp5);
        }
        if (hp <= 14)
        {
            Destroy(hp6);
        }
        if (hp <= 13)
        {
            Destroy(hp7);
        }
        if (hp <= 12)
        {
            Destroy(hp8);
        }
        if (hp <= 11)
        {
            Destroy(hp9);
        }
        if (hp <= 10)
        {
            Destroy(hp10);
        }
        if (hp <= 9)
        {
            Destroy(hp11);
        }
        if (hp <= 8)
        {
            Destroy(hp12);
        }
        if (hp <= 7)
        {
            Destroy(hp13);
        }
        if (hp <= 6)
        {
            Destroy(hp14);
        }
        if (hp <= 5)
        {
            Destroy(hp15);
        }
        if (hp <= 4)
        {
            Destroy(hp16);
        }
        if (hp <= 3)
        {
            Destroy(hp17);
        }
        if (hp <= 2)
        {
            Destroy(hp18);
        }
        if (hp <= 1)
        {
            Destroy(hp19);
        }
        if (hp <= 0)
        {
            Destroy(hp20);
        }
    }
}
