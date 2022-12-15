using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{

    public Text timeText;
    public float limit = 30.0f;
    public GameObject player;
    public GameObject text;
    public GameObject Text1;
    public GameObject TimeButton;
    public GameObject Name;

    private RestartManager restart;


    // Start is called before the first frame update
    void Start()
    {
        timeText.text = limit + "•b";

        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        if (restart.IsGameOver() && Input.GetKey(KeyCode.Space))
        {
            restart.Restart();

        }

        if (limit < 0)
        {
            restart.PrintGameOver();

            return;

        }


        if (Text1.activeSelf == true)
        {
            Time.timeScale = 0f;

            TimeButton.SetActive(true);
            Name.SetActive(true);
        }

            limit -= Time.deltaTime;
        timeText.text =  limit.ToString("f1") + "•b";




    }

   




}
