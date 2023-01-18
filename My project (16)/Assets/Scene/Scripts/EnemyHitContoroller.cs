using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitContoroller : MonoBehaviour
{
    public GameObject player;

    public GameObject text;

    public Coll col;

    private RestartManager restart;

    public GoalManager goal;


    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
        
    }

    // Update is called once per frame
    void Update()
    {


        if (col.Go == true && Input.GetKey(KeyCode.Space))
        {
            restart.Restart();
        
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name && goal.isGoal == false)
        {
            restart.IsGameOver();
            restart.PrintGameOver();
            
        }
    }
}
