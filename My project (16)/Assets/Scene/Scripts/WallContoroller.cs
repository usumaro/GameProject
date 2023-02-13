using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class WallContoroller : MonoBehaviour
{
    public float speed = 0.02f;
    public float max_x = 10.0f;
    public GameObject player;
    public GameObject GameOverText;
    private RestartManager restart;
    public Coll col;

    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(speed, 0, 0);
        
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
           speed *= -1;    
        }

        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)
        {
            restart.Restart();
            Debug.Log("Restart”»’è");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == player.name)
        {
            restart.PrintGameOver();
            Debug.Log("GameOver”»’è");
        }
    }
}
