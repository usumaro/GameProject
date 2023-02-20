using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class WallContoroller : MonoBehaviour
{
    public float speed = 0.02f;//障害物のスピード
    public float max_x = 10.0f;//障害物のｘ限界値
    public GameObject player;
    public GameObject GameOverText;
    private RestartManager restart;
    public Coll col;

    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    void Update()//障害物を往復させる
    {
        this.gameObject.transform.Translate(speed, 0, 0);
        
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
           speed *= -1;    
        }

        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)//ゲームオーバー時ENTERでリスタート
        {
            restart.Restart();
            Debug.Log("Restart判定");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == player.name)//障害物に触れたらゲームオーバー
        {
            restart.PrintGameOver();
            Debug.Log("GameOver判定");
        }
    }
}
