using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public Coll col;
    private bool isCount = false;
    private int rnd;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    void Start()
    {
      rnd = Random.Range(1, 4); // ※ 1～3の範囲でランダムな整数値が返る
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (col.isGameOver == true)//ゲームオーバー時にサウンドを再生
        {
            if (!isCount)
            {
                GetComponent<AudioSource>().Play();

                if (rnd == 1)//ゲームオーバー時にランダムにボイスを再生
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
    }
}