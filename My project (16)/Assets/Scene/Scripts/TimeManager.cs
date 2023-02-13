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

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = limit + "•b";
        restart = new RestartManager(player, GameOverText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && goal.isGoal == true)
        {
            restart.Restart();
            Debug.Log("Restart”»’è");
        }

        if (limit < 0)
        {
            restart.PrintGameOver();
            return;
        }
        if (goal.isGoal == true)
        {
            Time.timeScale = 0f;
        }
      
        limit -= Time.deltaTime;
        timeText.text =  limit.ToString("f1") + "•b";
    }
}
