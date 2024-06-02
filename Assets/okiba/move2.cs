using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    Vector3 a;    //ñ⁄ìIínÇÃç¿ïW
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screen_point = Input.mousePosition;
            this.a = Camera.main.ScreenToWorldPoint(screen_point);
            Debug.Log(a);
        }
    }
}