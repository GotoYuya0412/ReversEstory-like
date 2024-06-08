using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] float hp = 10f;
    [SerializeField] float Yellow = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bulet")
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
