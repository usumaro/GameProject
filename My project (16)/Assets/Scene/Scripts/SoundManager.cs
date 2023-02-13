using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Coll col;
    private bool isCount = false;
    
    void Update()
    {
        if (col.isGameOver == true)
        {
            if(!isCount)
            GetComponent<AudioSource>().Play();
            isCount = true ;
        }
    }
}