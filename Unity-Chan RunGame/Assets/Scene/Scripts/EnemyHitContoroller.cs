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

    private void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)//�Q�[���I�[�o�[����ENTER�Ń��X�^�[�g
        {
            Debug.Log("Restart����");
            restart.Restart();
        }
    }

    private void OnTriggerEnter(Collider other)//ENEMY�ɓ���������Q�[���I�[�o�[
    {
        if (other.gameObject.name == player.name)
        {
            Debug.Log("GameOver����");
            restart.PrintGameOver();
        }
    }
}
