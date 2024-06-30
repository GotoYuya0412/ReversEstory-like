using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public GameObject[] heart;
    [SerializeField] GameObject panelGameOver;
    int hp = 14;
    GameObject boss;
    BossHP bosshp;
    [SerializeField] GameObject panelclear;
    float timer = 0f;
    bool nullche = false;
    float interbal = 0f;
    [SerializeField] GameObject particleDamege;
    [SerializeField] GameObject particleDess;
    AudioSource audioSource;
    [SerializeField] GameObject audioDess;

    

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);
        panelclear.SetActive(false);
        boss = GameObject.Find("Boss");
        audioSource = GetComponent<AudioSource>();

        if (boss != null)
        {
            bosshp = boss.GetComponent<BossHP>();
            nullche = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nullche)
        {
            if (bosshp.hp <= 0)
            {
                timer += Time.deltaTime;

                if (timer > 5)
                {
                    panelclear.SetActive(true);
                }
            }
        }

        if (hp <= 0)
        {
            panelGameOver.SetActive(true);
            Instantiate(particleDess, transform.position, Quaternion.identity);
            Instantiate(audioDess, transform.position, Quaternion.identity);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<move3>().enabled = false;
            gameObject.GetComponent<Shoot>().enabled = false;
            gameObject.GetComponent<PlayerHp>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBulet")
        {
            if (hp > 0)
            {
                hp--;
                heart[hp].SetActive(false);
                Instantiate(particleDamege, transform.position, Quaternion.identity);
                audioSource.Play();
            }

            
        }
        if (collision.gameObject.tag == "EnemyBulet2")
        {
            if (hp > 0)
            {
                hp--;
                heart[hp].SetActive(false);
                hp--;
                heart[hp].SetActive(false);
                Instantiate(particleDamege, transform.position, Quaternion.identity);
                audioSource.Play();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        interbal -= Time.deltaTime;

        if (collision.gameObject.tag == "EnemyBuletStay" && interbal <= 0f)
        {
            if (hp > 0)
            {
                hp--;
                heart[hp].SetActive(false);
                interbal = 0.1f;
                Instantiate(particleDamege, transform.position, Quaternion.identity);
                audioSource.Play();
            }
        }
    }
}
