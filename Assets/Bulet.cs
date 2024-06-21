using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 a = new Vector2(100, 100) * 1.5f;
    bool b = false;
    GameObject cursol;
    GameObject player;
    bool kore = true;
    float time = 0;
    public Color orenge;
    public Color red;
    SpriteRenderer sp;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cursol = GameObject.Find("Cursol");
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && kore)
        {
            transform.position = player.transform.position;
            Vector2 a = cursol.transform.position - player.transform.position;
            float rad = Mathf.Atan2(a.y, a.x);
            float degree = (rad * Mathf.Rad2Deg) - 90f;
            transform.eulerAngles = new Vector3(0, 0, degree);

            time += Time.deltaTime;


        }

        if (Input.GetMouseButtonUp(1))
        {
            rb.velocity = this.transform.up * a;
            b = true;
            kore = false;

            Destroy(gameObject, 10);
        }



    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (b == true)
        {
            Destroy(this.gameObject);
        }
    }
}
