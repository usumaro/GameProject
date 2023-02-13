using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;
    public GameObject GoalText;
    public GameObject TimeButton;
    public GameObject InputName;
    public GameObject TopButton;

    private RestartManager restart;

    public bool isGoal = false;

    [SerializeField]
    AudioSource seAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && isGoal == true)
        {
            Time.timeScale = 1f;
            restart.Restart();
            Debug.Log("Restart判定");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == player.name)
        {
            GoalText.GetComponent<Text>().text = "Goal!!\nSpaceキーでリスタート";
            GoalText.SetActive(true);
            isGoal = true;
            seAudioSource.Play();

            TimeButton.SetActive(true);
            InputName.SetActive(true);
            TopButton.SetActive(true);
        }  
    }
}
