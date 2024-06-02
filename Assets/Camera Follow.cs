using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Circle;
    Vector3 a;

    void Start()
    {

    }

    void Update()
    {
        a = Vector3.Lerp(this.transform.position, Circle.position, Time.deltaTime * 3);
        a.z = -10f;
        this.transform.position = a;
    }
}
