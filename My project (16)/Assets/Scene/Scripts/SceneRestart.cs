using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    public GameObject TopButton;
   
    public void Button_Push()
    {
       Invoke("Top", 1.5f);
       Debug.Log("TOPÉÅÉjÉÖÅ[Ç…ñﬂÇËÇ‹Ç∑");
    }

    private void Top()
    {
        SceneManager.LoadScene("Top");
    }
}