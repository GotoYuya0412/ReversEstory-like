using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   [SerializeField] GameObject bulet;
    Rigidbody2D rb;
    GameObject buleta;
    GameObject cursol;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cursol = GameObject.Find("Cursol");
        // Update is called once per frame

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
     
             buleta = Instantiate(bulet);
            // buleta.transform.parent = this.transform;
 
        }

        if(buleta != null && Input.GetMouseButton(1))
        {
             buleta.transform.position = this.transform.position;
        Vector2 a = cursol.transform.position - transform.position;
        float rad = Mathf.Atan2(a.y, a.x);
        float degree = (rad * Mathf.Rad2Deg) - 90f;
        buleta.transform.eulerAngles = new Vector3(0, 0, degree);
        Debug.Log(degree);
        }

        //Vector3 a = this.transform.position;
        //Vector3 b = Input.mousePosition;
        //Vector3 c = Camera.main.ScreenToWorldPoint(b);
        //Vector3 d = new Vector3(0, 0, 10);
        //float e = Vector3.SignedAngle(a,c,d);
        //buleta.transform.eulerAngles = new Vector3(0f,0f,e);

    }
}
