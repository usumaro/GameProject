using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class WallContoroller : MonoBehaviour
{
    public float speed = 0.02f;//��Q���̃X�s�[�h
    public float max_x = 10.0f;//��Q���̂����E�l
    public GameObject player;
    public GameObject GameOverText;
    private RestartManager restart;
    public Coll col;

    void Start()
    {
        restart = new RestartManager(player, GameOverText);
    }

    void Update()//��Q��������������
    {
        this.gameObject.transform.Translate(speed, 0, 0);
        
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
           speed *= -1;    
        }

        if (Input.GetKey(KeyCode.Return) && col.isGameOver == true)//�Q�[���I�[�o�[��ENTER�Ń��X�^�[�g
        {
            restart.Restart();
            Debug.Log("Restart����");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == player.name)//��Q���ɐG�ꂽ��Q�[���I�[�o�[
        {
            restart.PrintGameOver();
            Debug.Log("GameOver����");
        }
    }
}
