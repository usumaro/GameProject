using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;
    public GameObject TopButton;
    public bool isGameOver = false;

    void Update()
    {
        if (GameOverText.activeSelf == true)//�Q�[���I�[�o�[�̔���p
        {
            isGameOver = true;
        }

        if (isGameOver == true)
        {
            TopButton.SetActive(true);
        }
    }
}