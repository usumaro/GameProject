using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject TopButton;
    public AudioClip sound1;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()//Topでマウスクリックでゲームへ
    {
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("Game", 1.5f);
            audioSource.PlayOneShot(sound1);
        }
     }

    public void ButtonPush()//ボタンを押したらTopへ戻る
    {
        Debug.Log("タイトルへ変遷中…");

        Invoke("Top", 1.0f);
    }

    void Game()
    {
        SceneManager.LoadScene("Game");
    }

    void Top()
    {
        SceneManager.LoadScene("Top");
    }
}