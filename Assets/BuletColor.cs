using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletColor : MonoBehaviour
{
    SpriteRenderer sp;
    public Color orenge;
    public Color red;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 1)
        {
            sp.color = orenge;
        }
        if(time > 2)
        {
            sp.color = red;
        }
    }
}
