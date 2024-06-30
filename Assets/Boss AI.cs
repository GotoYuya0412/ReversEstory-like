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
    public GameObject bulet41;
    public GameObject bulet42;
    Vector3 a;
    GameObject transform1;
    GameObject transform2;
    GameObject transform3;
    GameObject transformplayer;
    [SerializeField] GameObject player;
    float cooltime = 0;

    System.Action[] ai;
    int i;
    int shootcount = 0;

    System.Action[] shootai;
    int si;

    Vector2 v;
    Vector2 z;
    bool bb = true;
    bool move3 = false;
    float r = 0;
    bool move33 = true;
    GameObject bulet31;
    float Shoot3time = 0;
    float time = 0f;
    bool line = true;
    bool beam = true;
    Quaternion quaternion;

    bool b_audio = true;
    AudioSource audio1;

    BossHP bosshp;

    // Start is called before the first frame update
    void Start()
    {
        transform1 = GameObject.Find("Transform1");
        transform2 = GameObject.Find("Transform2");
        transform3 = GameObject.Find("Transform3");
        transformplayer = GameObject.Find("Player");
        ai = new System.Action[] { Move1, Move2, Move3, Move4};
        shootai = new System.Action[] { Shoot1, Shoot2, Shoot4 };
        i = Random.Range(0, ai.Length);
        i = 3;
        siRandom();
        audio1 = GetComponent<AudioSource>();
        bosshp = GetComponent<BossHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bosshp.hp > 0f)
        {

           time += Time.deltaTime;
          if (time > 2f)
           {
              ai[i]();
           }
        }
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

    void Move4()
    {
        a = Vector2.Lerp(transform.position, transform3.transform.position, Time.deltaTime * 3);
        transform.position = a;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (bosshp.hp > 0f)
        {

            if (collision.gameObject.tag == "Transform1" && !move3)
            {
                shootai[si]();
            }

            if(collision.gameObject.tag == "Transform2" && !move3)
            {
                shootai[si]();
            }

            if (collision.gameObject.tag == "Transform3" && !move3)
            {
                shootai[si]();
            }
        }
    }

    public void Shoot1()
    {
        if(cooltime > 0.1f)
        {
            Instantiate(bulet1, transform.position, Quaternion.identity);
            cooltime = 0f;
            shootcount += 1;
        }

        cooltime += Time.deltaTime;

        if(shootcount == 30)
        {
            shootcount = 0;
            cooltime = 0;
            iRandom();
            siRandom();
        }
    }

    public void Shoot2()
    {
        if(cooltime > 1)
        {
            Vector2 rad1 = player.transform.position - transform.position;
            float rad2 = Mathf.Atan2(rad1.y, rad1.x);
            float degree = (rad2 * Mathf.Rad2Deg);
            Vector3 rotate = new Vector3(0, 0, degree);
            quaternion = Quaternion.Euler(rotate);
            Instantiate(bulet2, transform.position, quaternion);
            cooltime = 0;
            shootcount += 1;
        }

        cooltime += Time.deltaTime;

        if (shootcount == 5)
        {
            shootcount = 0;
            cooltime = 0;
            iRandom();
            siRandom();
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
            if (b_audio)
            {
            audio1.Play();
                b_audio = false;
            }

            r += 360 * Time.deltaTime * 2;
        }

        if(r > 360)
        {
            iRandom();
            cooltime = 0;
            Destroy(bulet31);
            r = 0;
            move3 = false;
            move33 = true;
            bb = true;
            Shoot3time = 0;
            b_audio = true;
        }
    }

    public void Shoot4()
    {
        cooltime += Time.deltaTime;
        

        if (line && cooltime > 1f)
        {
            Vector2 rad1 = player.transform.position - transform.position;
            float rad2 = Mathf.Atan2(rad1.y, rad1.x);
            float degree = (rad2 * Mathf.Rad2Deg);
            Vector3 rotate = new Vector3(0, 0, degree);
            quaternion = Quaternion.Euler(rotate);
            GameObject lineob =  Instantiate(bulet41, transform.position, quaternion);
            Destroy(lineob, 2f);
            line = false;
        }

        if (beam && cooltime > 3f)
        {
            GameObject beamob =  Instantiate(bulet42, transform.position, quaternion);
            Destroy(beamob, 2f);
            beam = false;
        }

        if (cooltime > 5f)
        {
            iRandom();
            cooltime = 0f;
            line = true;
            beam = true;
            siRandom();
        }
    }
    void iRandom()
    {
        i = Random.Range(0, ai.Length);
    }

    void siRandom()
    {
        si = Random.Range(0, shootai.Length);
    }
}
