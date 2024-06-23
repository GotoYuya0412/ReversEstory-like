using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    [SerializeField] public float hp = 20f;
    [SerializeField] float maxhp = 20;
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
    public Canvas canvasdamege;
    GameObject text1;
    public Slider slider;
    float sliderx = 6.5f;
    float sliderscale;
    float canvasscale = 520;
    float hpscale;
    float slidertrp;
    RectTransform rect;
    [SerializeField] GameObject haretu;
    [SerializeField] GameObject particle;
    public float timerb = 0f;
    bool b_haretu = true;
    bool b_particle = true;
    GameObject haretu2;


    // Start is called before the first frame update
    void Start()
    {
        damege = text.GetComponent<Text>();
        sliderscale = 6.5f / hp;

        rect = slider.GetComponent<RectTransform>();

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

        sliderx = hp * sliderscale;
        if (sliderx < 0)
        {
            sliderx = 0;
        }

        hpscale = hp / maxhp;
        slidertrp = canvasscale - canvasscale * hpscale;
        slider.transform.localScale = new Vector3(sliderx, 4, 1);
        rect.anchoredPosition = new Vector3(-40, slidertrp, 0);

        //Debug.Log(slidertrp);

        if (hp <= 0)
        {
            timerb += Time.deltaTime;

            if (timerb > 0.5f && b_haretu)
            {
                haretu2 =  Instantiate(haretu, transform.position, Quaternion.identity);
                b_haretu = false;
            }
            if (timerb > 3f && b_particle)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                b_particle = false;
                Destroy(haretu2);
                Destroy(this.gameObject);
            }
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
            Instantiate(text, damegeposi, Quaternion.identity, canvasdamege.transform);

            //Destroy(collision.gameObject);
            orange = false;
            red = false;
        }

        //Debug.Log(hp);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Circle")
        {
            hp -= circle;
            Destroy(collision.gameObject);

            Vector2 posi = new Vector2(0.3f, 0.3f);
            Vector2 posi1 = transform.position;
            Vector2 damegeposi = posi + posi1;
            damege.text = "" + circle;
            Instantiate(text, damegeposi, Quaternion.identity, canvasdamege.transform);
        }

        //Debug.Log(hp);
    }
}