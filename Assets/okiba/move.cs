using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
{
    //[SerializeField] int power = 5;
    Rigidbody2D rb;
    public Vector2 mousePosition;
   

    // Start is called before the first frame update
    public void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //Vector3 playerPosition = this.transform.position;
        //Vector3 b = wouldmouse.normalized * power;
        //Vector2 a = wouldmouse - playerPosition;
        //Vector2 playerPosition = this.transform.position;
        

        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            Vector2 wouldmouse = Camera.main.WorldToScreenPoint(mousePosition);
            //transform.position = a;
            Debug.Log(wouldmouse);
            //rb.velocity = new Vector3(0,0);
            //rb.AddForce(b,ForceMode2D.Impulse);
            
        }
    }
}
