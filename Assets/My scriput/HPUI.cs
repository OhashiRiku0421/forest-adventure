using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] GameObject hp1;
    [SerializeField] GameObject hp2;
    [SerializeField] GameObject hp3;
    [SerializeField] GameObject hp4;
    [SerializeField] GameObject hp5;
    public static float hp = 5;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(hp <= 5)
        {
            hp1.SetActive(true);
        }
        if (hp <= 4)
        {
            hp1.SetActive(false);
            hp2.SetActive(true);

        }
        if (hp <= 3)
        {
            hp2.SetActive(false);
            hp3.SetActive(true);

        }
        if (hp <= 2)
        {
            hp3.SetActive(false);
            hp4.SetActive(true);
        }
        if (hp <= 1)
        {
            hp4.SetActive(false);
            hp5.SetActive(true);
        }
        if (hp <= 0)
        {
            hp5.SetActive(false);
        }
    }
}
