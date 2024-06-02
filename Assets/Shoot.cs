using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   [SerializeField] GameObject bulet = default;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Update is called once per frame

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
     
            GameObject buleta = Instantiate(bulet);
            buleta.transform.position = this.transform.position;
            buleta.transform.parent = this.transform;
        }

        Vector3 a = this.transform.position;
        Vector3 b = Input.mousePosition;
        Vector3 c = Camera.main.ScreenToWorldPoint(b);
        Vector3 d = new Vector3(0, 0, 10);
        float e = Vector3.SignedAngle(a,c,d);
        this.transform.eulerAngles = new Vector3(0f,0f,e);
    }
}
