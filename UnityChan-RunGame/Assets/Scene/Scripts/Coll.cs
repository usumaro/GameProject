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
        if (GameOverText.activeSelf == true)//ゲームオーバーの判定用
        {
            isGameOver = true;
        }

        if (isGameOver == true)
        {
            TopButton.SetActive(true);
        }
    }
}