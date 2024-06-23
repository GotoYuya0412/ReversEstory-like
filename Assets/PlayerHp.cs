using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public GameObject[] heart;
    [SerializeField] GameObject panelGameOver;
    int hp = 7;

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
