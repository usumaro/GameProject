using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess5 : MonoBehaviour
{
   private GameObject Ghost ;


    public void Button_Push()
    {
        Ghost = GameObject.Find("Ghost");

        Transform myTransform = Ghost.transform;

        Vector3 pos = myTransform.position;


        StartCoroutine("Access");




    }



    private IEnumerator Access()
    {


        StartCoroutine(Post("http://localhost/dbaccess/selecttest6.php"));


        yield return 0;
    }





    private IEnumerator Post(string url)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.error != null)
            {
                Debug.Log("HttpPost NG;"+ www.error);

            }
            else if (www.isDone)
            {

                float[] data = www.downloadHandler.text.Split(',');
                pos.x = data[1];
                pos.y = data[2];
                pos.z = data[3];
                    
                myTransform.position = pos;
            }





        }
    }








}





