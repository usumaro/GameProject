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
        // コルーチンの起動
        StartCoroutine(DelayCoroutine());
        Debug.Log("TOPへ戻ります");
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSecondsRealtime(1); // 1秒間待つ
        SceneManager.LoadScene("Top");
        Debug.Log("TOPメソッド");
    }
}