using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeText;
    public float limit = 30.0f;
    public GameObject player;
    public GameObject GameOverText;
    public GoalManager goal;
  
    public Coll col;
    private RestartManager restart;

    void Start()
    {
        timeText.text = limit + "秒";
        restart = new RestartManager(player, GameOverText);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && goal.isGoal == true)//ゴールしてENTERを押したらリスタート
        {
            restart.Restart();
            Debug.Log("Restart判定");
        }

        if (limit < 0)//０秒になったらゲームオーバー
        {
            restart.PrintGameOver();
            return;
        }
        if (goal.isGoal == true)//ゴールしていたらカウントダウンをストップ
        {
            Time.timeScale = 0f;
        }
      
        limit -= Time.deltaTime;
        timeText.text =  limit.ToString("f1") + "秒";//カウントダウン３０秒
    }
}
