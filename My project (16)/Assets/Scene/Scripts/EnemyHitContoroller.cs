using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitContoroller : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;
    public Coll col;
    private RestartManager restart;
    public GoalManager goal;

    // Start is called before the first frame update
    private void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)
        {
            Debug.Log("Restart”»’è");
            restart.Restart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            Debug.Log("GameOver”»’è");
            restart.PrintGameOver();
        }
    }
}
