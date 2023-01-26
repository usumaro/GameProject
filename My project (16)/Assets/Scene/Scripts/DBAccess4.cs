using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess4 : MonoBehaviour
{



    public void Start()
    {


        StartCoroutine("Access");




    }



    private IEnumerator Access()
    {


        StartCoroutine(Post("http://localhost/dbaccess/resetpositiontable.php"));


        yield return 0;
    }





    private IEnumerator Post(string url)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

          

          

        }
    }








}





