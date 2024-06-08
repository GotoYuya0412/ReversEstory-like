using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursol = Input.mousePosition;
        Vector2 cursolPosi = Camera.main.ScreenToWorldPoint(cursol);
        this.transform.position = cursolPosi;

        //if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        //{
        //    Cursor.visible = false;
        //}
    }
}
