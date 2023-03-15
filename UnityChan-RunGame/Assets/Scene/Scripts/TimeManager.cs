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

    void Start()
    {
        timeText.text = limit + "�b";
        restart = new RestartManager(player, GameOverText);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && goal.isGoal == true)//�S�[������ENTER���������烊�X�^�[�g
        {
            restart.Restart();
            Debug.Log("Restart����");
        }

        if (limit < 0)//�O�b�ɂȂ�����Q�[���I�[�o�[
        {
            restart.PrintGameOver();
            return;
        }
        if (goal.isGoal == true)//�S�[�����Ă�����J�E���g�_�E�����X�g�b�v
        {
            Time.timeScale = 0f;
        }
      
        limit -= Time.deltaTime;
        timeText.text =  limit.ToString("f1") + "�b";//�J�E���g�_�E���R�O�b
    }
}
