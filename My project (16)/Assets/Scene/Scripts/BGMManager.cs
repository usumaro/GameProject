using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public Coll col;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (col.isGameOver == true)
        {
            audioSource.Stop();
        }
    }
}

