using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Coll col;
    private bool isCount = false;
    
    void Update()
    {
        if (col.isGameOver == true)//�Q�[���I�[�o�[���ɃT�E���h���Đ�
        {
            if(!isCount)
            GetComponent<AudioSource>().Play();
            isCount = true ;
        }
    }
}