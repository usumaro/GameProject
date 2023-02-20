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

    void Update()//Top�Ń}�E�X�N���b�N�ŃQ�[����
    {
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("Game", 1.5f);
            audioSource.PlayOneShot(sound1);
        }
     }

    public void ButtonPush()//�{�^������������Top�֖߂�
    {
        Debug.Log("�^�C�g���֕ϑJ���c");

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