using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public Coll col;
    public GoalManager goal;
    private bool isCount = false;
    private int rnd;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;

    void Start()
    {
      rnd = Random.Range(1, 4); // �� 1�`3�͈̔͂Ń����_���Ȑ����l���Ԃ�
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (col.isGameOver == true)//�Q�[���I�[�o�[���ɃT�E���h���Đ�
        {
            if (!isCount)
            {
                GetComponent<AudioSource>().Play();

                if (rnd == 1)//�Q�[���I�[�o�[���Ƀ����_���Ƀ{�C�X���Đ�
                {
                    audioSource.PlayOneShot(sound1,2.0F);
                }
                else if(rnd == 2)
                {
                    audioSource.PlayOneShot(sound2, 2.0F);
                }
                else if(rnd == 3)
                {
                    audioSource.PlayOneShot(sound3, 2.0F);
                }

                isCount = true;
            }
        }

        if (goal.isGoal == true)
        {
            if (!isCount)
            {
                if (rnd == 1)//�S�[�����Ƀ����_���Ƀ{�C�X���Đ�
                {
                    audioSource.PlayOneShot(sound4, 2.0F);
                    Debug.Log("�I�[�f�B�I4");
                }
                else if (rnd == 2)
                {
                    audioSource.PlayOneShot(sound5, 2.0F);
                    Debug.Log("�I�[�f�B�I5");
                }
                else if (rnd == 3)
                {
                    audioSource.PlayOneShot(sound6, 2.0F);
                    Debug.Log("�I�[�f�B�I6");
                }
                isCount = true;
            }
        }
    }
}