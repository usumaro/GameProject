using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public GameObject player;
    public GameObject text1;

    public bool isGoal = false;

    [SerializeField]
    AudioSource seAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoal == true && Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1f;
            Restart();
        
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.name == player.name)
        {

            text1.GetComponent<Text>().text = "Goal!!\nSpaceキーでリスタート";

            text1.SetActive(true);

            isGoal = true;

            seAudioSource.Play();

        }    
   
    
    }


    private void Restart()
    {

        Scene loadScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(loadScene.name);
    
    
    }





}
