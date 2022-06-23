using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    static Title title;
    // Start is called before the first frame update
    private void Awake()
    {
        if(title == null)
        {
            title = this;
            DontDestroyOnLoad(title);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
