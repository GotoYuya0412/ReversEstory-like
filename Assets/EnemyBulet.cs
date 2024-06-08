using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulet : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector2 a;
    bool aa = true;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(aa)
        {
            a = player.transform.position - transform.position;
            Vector2 b = a.normalized * speed;
            rb.velocity = b;
            aa = false;
        }
 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
