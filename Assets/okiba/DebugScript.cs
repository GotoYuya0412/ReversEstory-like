using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    public void Onclick()
    {
        Debug.Log("�q���V�ł�...�N���b�N�����Ƃ��ꂵ���Ƃł�...");
        SceneManager.LoadScene("SampleScene");
    }
}