using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] float hp = 10f;
    [SerializeField] float Yellow = 5f;
    bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            b = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            b = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bulet" && b)
        {
            hp -= Yellow;
            Destroy(collision.gameObject);
        }

        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
