using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    public void Onclick()
    {
        Debug.Log("ヒロシです...クリックされるとうれしいとです...");
        SceneManager.LoadScene("SampleScene");
    }
}