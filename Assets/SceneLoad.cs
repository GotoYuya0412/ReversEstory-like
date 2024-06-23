using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        time += Time.deltaTime;

        if (time > 0.5f)
        {
            GetComponent<AudioSource>().Play();
            GameObject.Find("Player").SetActive(false);
            Invoke("LoadMain", 1f);
        }
    }

    void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        time = 0f;
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadReStrat()
    {
        SceneManager.LoadScene("Main");
    }
}
