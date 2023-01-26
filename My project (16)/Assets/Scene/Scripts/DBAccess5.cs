using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess5 : MonoBehaviour
{
   private GameObject Ghost ;

    float px;
    float py;
    float pz;


    public void Start()
    {

        Ghost = GameObject.Find("Ghost");

        



    }


    public void Button_Push()
    {
        

        StartCoroutine("Access");

        Transform myTransform = Ghost.transform;

        Vector3 pos = myTransform.position;

        pos.x = px;
        pos.y = py;
        pos.z = pz;

        myTransform.position = pos;
    }



    private IEnumerator Access()
    {


        StartCoroutine(Post("http://localhost/dbaccess/positioninput.php"));


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

                string[] data = www.downloadHandler.text.Split('/');
                px = float.Parse(data[1]);
                py = float.Parse(data[2]);
                pz = float.Parse(data[3]);


            }





        }
    }








}





