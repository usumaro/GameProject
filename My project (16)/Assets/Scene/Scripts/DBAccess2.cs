using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess2 : MonoBehaviour
{
    public GameObject BestTimeText;
    

   void Start()
    {
        StartCoroutine("Access");
     
    }


    private IEnumerator Access()
    {
        

        StartCoroutine("http://localhost/dbaccess/selecttest2.php");
      

        yield return 0;
    }

    private IEnumerator Post(string url)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            string[] data = www.downloadHandler.text.Split(',');

            BestTimeText.GetComponent<Text>().text = data[1];
        
        }
    
    }

        
    



}



    

