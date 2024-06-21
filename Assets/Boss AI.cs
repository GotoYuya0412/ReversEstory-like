using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class BossAI : MonoBehaviour
{
    public GameObject bulet1;
    public GameObject bulet2;
    public GameObject bulet3;
    Vector3 a;
    GameObject transform1;
    GameObject transform2;
    GameObject transformplayer;
    //float time = 0;
    float cooltime = 0;
    System.Action[] ai;
    int i;
    int shootcount = 0;
    Vector2 v;
    Vector2 z;
    bool bb = true;
    bool move3 = false;
    float r = 0;
    bool move33 = true;
    GameObject bulet31;
    float Shoot3time = 0;



    void A()
    {
        Debug.Log(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform1 = GameObject.Find("Transform1");
        transform2 = GameObject.Find("Transform2");
        transformplayer = GameObject.Find("Player");
        ai = new System.Action[] { Move1, Move2, Move3};
        //i = Random.Range(0, ai.Length);
        i = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Move1();
        ai[i]();
        //Debug.Log(shootcount);
    }
    void Move1()
    {
        a = Vector2.Lerp(transform.position, transform1.transform.position, Time.deltaTime * 3);
        transform.position = a;
    }

    public void Move2()
    {
        a = Vector2.Lerp(transform.position, transform2.transform.position, Time.deltaTime * 3);
        transform.position = a;
    }

    public void Move3()
    {
        move3 = true;

        if (bb)
        {
            v = transformplayer.transform.position;
            bb = false;
        }
        a = Vector2.Lerp(transform.position, v, Time.deltaTime * 3);
        transform.position = a;

        Shoot3time += Time.deltaTime;

        if (Shoot3time > 0.5f)
        {
            Shoot3();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transform1" && !move3)
        {
            Shoot1();
        }

        if(collision.gameObject.tag == "Transform2" && !move3)
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
            i = 2;
        }
    }

    public void Shoot3()
    {
        if (move33)
        {
            bulet31 =  Instantiate(bulet3, transform.position, Quaternion.identity);
            move33 = false;
        }

        if (bulet31 != null)
        {
        bulet31.transform.position = transform.position;

        }

        cooltime += Time.deltaTime;

        if(cooltime > 1)
        {
            transform.eulerAngles = new Vector3(0, 0, r);
            bulet31.transform.eulerAngles = new Vector3(0, 0, r);

            r += 360 * Time.deltaTime;
        }

        if(r > 360)
        {
            i = 0;
            cooltime = 0;
            Destroy(bulet31);
            r = 0;
            move3 = false;
            move33 = true;
            bb = true;
            Shoot3time = 0;
        }
    }
}
