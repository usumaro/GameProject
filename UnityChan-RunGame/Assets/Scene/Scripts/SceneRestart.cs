using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    public GameObject TopButton;

    void Button_Push()
    {  
        StartCoroutine(DelayCoroutine()); // �R���[�`���̋N��
        Debug.Log("TOP�֖߂�܂�");
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSecondsRealtime(1); // 1�b�ԑ҂�
        SceneManager.LoadScene("Top");
        Debug.Log("TOP���\�b�h");
    }
}