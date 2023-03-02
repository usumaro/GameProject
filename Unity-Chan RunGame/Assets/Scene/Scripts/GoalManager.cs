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

    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && isGoal == true)//�S�[������ENTER�Ń��X�^�[�g
        {
            Time.timeScale = 1f;
            restart.Restart();
            Debug.Log("Restart����");
        }
    }

    public void OnTriggerEnter(Collider other)//�S�[��������T�E���h�ƃe�L�X�g�E�{�^����\��
    {
        if (other.name == player.name)
        {
            GoalText.GetComponent<Text>().text = "Goal!!\nENTER�L�[�Ń��X�^�[�g";
            GoalText.SetActive(true);
            isGoal = true;
            seAudioSource.Play();

            TimeButton.SetActive(true);
            InputName.SetActive(true);
            TopButton.SetActive(true);
        }  
    }
}
