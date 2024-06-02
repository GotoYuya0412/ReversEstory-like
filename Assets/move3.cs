using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class move3 : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePosition;
    [SerializeField] float currentPower = 5f;
    Vector2 a = new Vector2(3 , 3);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screen_point = Input.mousePosition;
            this.mousePosition = Camera.main.ScreenToWorldPoint(screen_point);
            Vector2 playerPosition = this.transform.position;
            Vector2 force = this.mousePosition - playerPosition;

            //if (-5 < force.x && force.x < 5 && -5 < force.y && force.y < 5)
            //{
            //    if (0 < force.x && force.x < 5)
            //    {
            //        force.x = 5;
            //    }

            //    if (-5 < force.x && force.x < 0)
            //    {
            //        force.x = -5;
            //    }

            //    if (0 < force.y && force.y < 5)
            //    {
            //        force.y = 5;
            //    }

            //    if (-5 < force.y && force.y < 0)
            //    {
            //        force.y = -5;
            //    }
            //}

            //if (-5 < force.x && force.x < 5 && -5 < force.y && force.y < 5)
            //{
            //    if(4 < force.x || force.x < -4 || 4 < force.y || force.y < -4)
            //    {
            //        force.x = force.x * 1.1f;
            //        force.y = force.y * 1.1f;
            //        return;
            //    }

            //    if (3 < force.x || force.x < -3 || 3 < force.y || force.y < -3)
            //    {
            //        force.x = force.x * 1.5f;
            //        force.y = force.y * 1.5f;
            //        return;
            //    }

            //    if (2 < force.x || force.x < -2 || 2 < force.y || force.y < -2)
            //    {
            //        force.x = force.x * 2.4f;
            //        force.y = force.y * 2.4f;
            //        return;
            //    }

            //    if (1 < force.x || force.x < -1 || 1 < force.y || force.y < -1)
            //    {
            //        force.x = force.x * 4f;
            //        force.y = force.y * 4f;
            //        return;
            //    }
          
            //}



                //Vector2 force = (this.mousePosition - playerPosition) * currentPower;
                rb.velocity = new Vector2(0,0);
            rb.velocity = force;
            force = new Vector2(0,0);


            Debug.Log(mousePosition);
            Debug.Log(playerPosition);
            Debug.Log(mousePosition.normalized);
            Debug.Log(playerPosition.normalized);
        }
    }
}