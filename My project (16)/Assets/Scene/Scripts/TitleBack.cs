using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleBack : MonoBehaviour
{
    public GameObject TopButton;
   
    public void OnClick()
    {
        Debug.Log("�^�C�g���֕ϑJ���c");
        
        Invoke("ChangeScene", 1.0f);
    }

    // Update is called once per frame
    public void ChangeScene()
    {
        SceneManager.LoadScene("Top");
    }
}
