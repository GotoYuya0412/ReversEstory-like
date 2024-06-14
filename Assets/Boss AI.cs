using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class BossAI : MonoBehaviour
{
    public GameObject bulet1;
    public GameObject bulet2;
    Vector3 a;
    GameObject transform1;
    GameObject transform2;
    //float time = 0;
    float cooltime = 0;
    System.Action[] ai;
    int i;
    int shootcount = 0;



    void A()
    {
        Debug.Log(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform1 = GameObject.Find("Transform1");
        transform2 = GameObject.Find("Transform2");
        ai = new System.Action[] { Move1, Move2 };
        i = Random.Range(0, ai.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //Move1();
        ai[i]();
        Debug.Log(shootcount);
    }
    void Move1()
    {
        a = Vector2.Lerp(transform.position, transform1.transform.position, Time.deltaTime * 10);
        transform.position = a;
    }

    public void Move2()
    {
        a = Vector2.Lerp(transform.position, transform2.transform.position, Time.deltaTime * 3);
        transform.position = a;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transform1")
        {
            Shoot1();
        }

        if(collision.gameObject.tag == "Transform2")
        {
            Shoot2();
        }
    }

    public void Shoot1()
    {
        if(cooltime <= 0)
        {
            Instantiate(bulet1, transform.position, Quaternion.identity);
            cooltime = 0.1f;
            shootcount += 1;
        }

        cooltime -= Time.deltaTime;

        if(shootcount == 30)
        {
            //i = Random.Range(0, ai.Length);
            shootcount = 0;
            cooltime = 0;
            i = 1;
        }
    }

    public void Shoot2()
    {
        if(cooltime <= 0)
        {
            Instantiate(bulet2, transform.position, Quaternion.identity);
            cooltime = 1;
            shootcount += 1;
        }

        cooltime -= Time.deltaTime;

        if (shootcount == 5)
        {
            //i = Random.Range(0, ai.Length);
            shootcount = 0;
            cooltime = 0;
            i = 0;
        }
    }
}
