using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class RestartManager : MonoBehaviour
{
    public GameObject player;
    public GameObject text;

   


    public bool isGameOver = false;

   

    public RestartManager(GameObject player, GameObject text)
    {
        this.player = player;
        this.text = text;
     
    }
    public void PrintGameOver()
    {

        text.GetComponent<Text>().text = "GameOver...";
            text.SetActive(true);

            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            player.GetComponent<Animator>().enabled = false;

    }
 
 

    public void Restart()
    {

        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);

    }

    public bool IsGameOver()
    {
        isGameOver = true;
        return isGameOver;
        
    }

}
