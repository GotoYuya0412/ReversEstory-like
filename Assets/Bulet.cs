using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 a = new Vector2(100,100);
    bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            b = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
           rb.velocity = this.transform.up * a;
            b = true;
        }
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(b == true)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (b == true)
        {
            Destroy(this.gameObject);
        }
    }

    //public void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (b == true)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
