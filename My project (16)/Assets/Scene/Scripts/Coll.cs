using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    public GameObject player;
    public GameObject GameOverText;
    public bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (GameOverText.activeSelf == true)
        {
            isGameOver = true;
        }
    }
}

    
