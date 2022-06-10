using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] GameObject hp1;
    [SerializeField] GameObject hp2;
    [SerializeField] GameObject hp3;
    [SerializeField] GameObject hp4;
    [SerializeField] GameObject hp5;
    [SerializeField] GameObject boss;
    public static int hp = 5;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 4)
        {
            Destroy(hp1);
        }
        if (hp <= 3)
        {
            Destroy(hp2);
        }
        if (hp <= 2)
        {
            Destroy(hp3);
        }
        if (hp <= 1)
        {
            Destroy(hp4);
        }
        if (hp <= 0)
        {
            Destroy(hp5);
        }
    }
}
