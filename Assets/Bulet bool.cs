using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buletbool : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
