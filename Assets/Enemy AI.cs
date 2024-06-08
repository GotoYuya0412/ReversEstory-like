using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //LayerMask layerMask = 1 << LayerMask.NameToLayer("Player");
        //Vector2 temp = player.transform.position - transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, temp,100f,layerMask);
        ////Debug.Log(hit.collider.gameObject.name);

        //if(hit.collider.gameObject.tag == "Player")
        //{
        //    Debug.Log("1");
        //}
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("1");
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Player");
        Vector2 temp = player.transform.position - transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, temp, 100f, layerMask);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, temp, 100f);
        Debug.Log(hit.collider.gameObject.name);

        if (hit)
        {
            if (hit.collider.gameObject.tag == "Player")
            {

                Debug.Log("1");
            }

        }
    }
}
