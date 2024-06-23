using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public GameObject[] heart;
    [SerializeField] GameObject panelGameOver;
    int hp = 7;
    GameObject boss;
    BossHP bosshp;
    [SerializeField] GameObject panelclear;
    float timer = 0f;
    bool nullche = false;
    

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);
        panelclear.SetActive(false);
        boss = GameObject.Find("Boss");

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBulet")
        {
            if (hp > 0)
            {
                hp--;
                heart[hp].SetActive(false);
            }

            if (hp <= 0)
            {
                panelGameOver.SetActive(true);
            }
        }
    }
}
