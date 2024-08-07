using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] float hp = 20f;
    [SerializeField] float Yellow = 10f;
    [SerializeField] float orange1 = 20f;
    [SerializeField] float red1 = 30f;
    [SerializeField] float circle = 3f;
    bool b = false;
    float time;
    bool orange = false;
    bool red = false;
    public GameObject text;
    Text damege;
    public Canvas canvas;
    GameObject text1;

    // Start is called before the first frame update
    void Start()
    {
        damege = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            b = false;
            time += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(1))
        {
            b = true;
            time = 0;
        }


        if (time > 1)
        {
            orange = true;
        }
        if (time > 2)
        {
            red = true;
        }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bulet" && b)
        {


            if (red)
            {
                hp -= red1;
                damege.text = "" + red1;
            }
            else if (orange)
            {
                hp -= orange1;
                damege.text = "" + orange1;
            }
            else
            {
                hp -= Yellow;
                damege.text = "" + Yellow;
            }

            Vector2 posi = new Vector2(0.3f, 0.3f);
            Vector2 posi1 = transform.position;
            Vector2 damegeposi = posi + posi1;
            Instantiate(text, damegeposi, Quaternion.identity, canvas.transform);

            //Destroy(collision.gameObject);
            orange = false;
            red = false;
        }

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

        Debug.Log(hp);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Circle")
        {
            hp -= circle;
            Destroy(collision.gameObject);

        Vector2 posi = new Vector2(0.3f, 0.3f);
        Vector2 posi1 = transform.position;
        Vector2 damegeposi = posi + posi1;
        damege.text = "" + circle;
        Instantiate(text, damegeposi, Quaternion.identity, canvas.transform);
        }


        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }

        //Debug.Log(hp);
    }
}
