using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
   [SerializeField] GameObject bulet;
    public GameObject bulet2;
    Rigidbody2D bulet2rb;
    Rigidbody2D rb;
    GameObject buleta;
    GameObject cursol;

    GameObject[] enemy;
    float s = 40;
    float distans;
    float t;
    GameObject nearenemy;
    float bulettime = 0;
    bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cursol = GameObject.Find("Cursol");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        distans = s;
        // Update is called once per frame

    }

    void Update()
    {
        if (Input.GetMouseButton(1) )
        {
            bulettime += Time.deltaTime;

            if(bulettime > 0.3 && b)
            {
                Vector2 a = cursol.transform.position - transform.position;
                float rad = Mathf.Atan2(a.y, a.x);
                float degree = (rad * Mathf.Rad2Deg) - 90f;

                buleta = Instantiate(bulet, transform.position, Quaternion.Euler(0,0,degree));
                b = false;
            }
           
        }

        //if (buleta != null && Input.GetMouseButton(1))
        //{
        //     buleta.transform.position = this.transform.position;
        //     Vector2 a = cursol.transform.position - transform.position;
        //     float rad = Mathf.Atan2(a.y, a.x);
        //     float degree = (rad * Mathf.Rad2Deg) - 90f;
        //     buleta.transform.eulerAngles = new Vector3(0, 0, degree);
        //}

        if(Input.GetMouseButtonUp(1))
        {

            if(bulettime <= 0.3)
            {
                foreach (GameObject near in enemy)
                {
                    
                    if(near != null)
                    {
                    t = Vector2.Distance(transform.position, near.transform.position);

                    }
                    
                    if (distans > t)
                    {
                        distans = t;
                        nearenemy = near;

                    }
                }


                if (distans < s)
                {
                    GameObject bulet22 = Instantiate(bulet2, transform.position, Quaternion.identity);
                    bulet2rb = bulet22.GetComponent<Rigidbody2D>();
                    Vector2 v = (nearenemy.transform.position - transform.position).normalized * 30;
                    bulet2rb.velocity = v;

                    distans = s;

                }
            }

            bulettime = 0;
            b = true;
        }

        //Vector3 a = this.transform.position;
        //Vector3 b = Input.mousePosition;
        //Vector3 c = Camera.main.ScreenToWorldPoint(b);
        //Vector3 d = new Vector3(0, 0, 10);
        //float e = Vector3.SignedAngle(a,c,d);
        //buleta.transform.eulerAngles = new Vector3(0f,0f,e);

        

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    foreach(GameObject near in enemy)
        //    {
        //        t = Vector2.Distance(transform.position, near.transform.position);
        //        if(distans > t)
        //        {
        //            distans = t;
        //            nearenemy = near;

        //        }
        //    }


        //    if (distans < s)
        //    {
        //        GameObject bulet22 = Instantiate(bulet2, transform.position, Quaternion.identity);
        //        bulet2rb = bulet22.GetComponent<Rigidbody2D>();
        //        Vector2 v = (nearenemy.transform.position - transform.position).normalized * 30;
        //        bulet2rb.velocity = v;

        //        distans = s;

        //    }
        //}

    }
}
