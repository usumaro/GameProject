using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public Coll col;
    public AudioSource audioSource;

    void Update()
    {
        if (col.isGameOver == true)//�Q�[���I�[�o�[��BGM��~
        {
            audioSource.Stop();
        }
    }
}

