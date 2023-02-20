using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
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

    void Game()
    {
        SceneManager.LoadScene("Game");
    }
}