using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess1 : MonoBehaviour
{
    
    public GameObject inputField;
    public GameObject PlaceHolder;
    public GameObject Time;

    public void Button_Push()
    {

        inputField = GameObject.Find("InputName");
        PlaceHolder = GameObject.Find("Placeholder");
        
        Time = GameObject.Find("Time");

        if (inputField == null || == "")
        {PlaceHolder.GetComponent<Text>().text = "–¼‘O‚ª‹ó—“‚Å‚·";
        }else{ StartCoroutine("Access"); }
      
    }


    private IEnumerator Access()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("time1", Time.GetComponent<Text>().text);
        dic.Add("name1", inputField.GetComponentInChildren<InputField>().text);


        StartCoroutine(Post("http://localhost/dbaccess/selecttest1.php", dic));
      

        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

        }


    }



}



    

