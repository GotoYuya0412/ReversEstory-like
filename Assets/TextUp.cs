using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 v = new Vector2(0, Time.deltaTime * 4);
            Vector2 vv = transform.position;
            transform.position = vv + v;
            Destroy(gameObject, 1);
    }
}
