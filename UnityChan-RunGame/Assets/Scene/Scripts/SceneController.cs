using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    AudioSource audioSource;
    private int rnd;
    public AudioClip sound1;
    public bool isCount = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()//Topでマウスクリックでゲームへ
    {
        if (Input.GetKey(KeyCode.Return) && isCount == false)
        {
            Time.timeScale = 1;
            Invoke("Game", 1.5f);
            audioSource.PlayOneShot(sound1);
            isCount = true;
        }
    }

    void Game()
    {
        SceneManager.LoadScene("Game");
    }
}