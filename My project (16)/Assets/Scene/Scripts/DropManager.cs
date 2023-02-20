using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;
    private RestartManager restart;
    public Coll col;

    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    void Update()
    {
        if (player.transform.position.y < -10) //-10まで落ちたらゲームオーバー
        {
            restart.PrintGameOver();
            Debug.Log("GameOver判定");
        }

        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)//ゲームオーバー且つENTERでリスタート
        {
            restart.Restart();
            Debug.Log("Restart判定");
        }
    }
}
