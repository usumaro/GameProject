using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BestTime : MonoBehaviour
{
    public GameObject BestTimeText;
    public float btt;
   
   void Start()
    {
        BestTimeText = GameObject.Find("BestTimeText");
        StartCoroutine("Access");
    }

    private IEnumerator Access()
    {
        StartCoroutine(Post("http://localhost/dbaccess/loadbesttime.php"));    
        yield return 0;
    }

    private IEnumerator Post(string url)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            btt = float.Parse(www.downloadHandler.text);
            BestTimeText.GetComponent<Text>().text ="BestTime :"+ www.downloadHandler.text + "•b";
        }    
    }
}



    

