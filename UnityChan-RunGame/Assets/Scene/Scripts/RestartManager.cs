using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class RestartManager : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;

    public RestartManager(GameObject player, GameObject GameOverText)
    {
        this.player = player;
        this.GameOverText = GameOverText;
    }
    public void PrintGameOver()//ゲームオーバーを表示する
    {
        GameOverText.GetComponent<Text>().text = "GameOver...";
        GameOverText.SetActive(true);

        player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
    }
 
    public void Restart()//ゲームをリスタートする
    {   
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}
