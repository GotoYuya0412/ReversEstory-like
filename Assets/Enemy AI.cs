using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject EnemyBulet;
    float time = 0;
    [SerializeField] float cool;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        //LayerMask layerMask = 1 << LayerMask.NameToLayer("Player");
        //Vector2 temp = player.transform.position - transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, temp,100f,layerMask);
        ////Debug.Log(hit.collider.gameObject.name);

        //if(hit.collider.gameObject.tag == "Player")
        //{
        //    Debug.Log("1");
        //}
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Player");
        Vector2 temp = player.transform.position - transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, temp, 100f, layerMask);
        hit = Physics2D.Raycast(transform.position, temp, 100f);
        Debug.DrawRay(transform.position, temp);

        if (hit)
        {
            if (hit.collider.gameObject.tag == "Player" && time <= 0)
            {
                Instantiate(EnemyBulet, transform.position, Quaternion.identity);
                time = cool;
            }

        }
    }
}
