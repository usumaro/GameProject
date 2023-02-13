using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;
    private RestartManager restart;
    public Coll col;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            restart.PrintGameOver();
            Debug.Log("GameOver”»’è");
        }

        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)
        {
            restart.Restart();
            Debug.Log("Restart”»’è");
        }
    }
}
