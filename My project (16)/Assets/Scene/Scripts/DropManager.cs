using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;
    private RestartManager restart;
    public Coll col;

    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    void Update()
    {
        if (player.transform.position.y < -10) //-10�܂ŗ�������Q�[���I�[�o�[
        {
            restart.PrintGameOver();
            Debug.Log("GameOver����");
        }

        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)//�Q�[���I�[�o�[����ENTER�Ń��X�^�[�g
        {
            restart.Restart();
            Debug.Log("Restart����");
        }
    }
}
