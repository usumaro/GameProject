using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess3 : MonoBehaviour
{
    GameObject Ghost;
    GameObject Player;

    string xp = "";
    string yp = "";



    public void Start()
    {

        Player = GameObject.Find("Player");
        Ghost = GameObject.Find("Ghost");
        
      

        

        
      
    }

    public void Update()
    {
        Vector3 posi = Player.transform.position;
        xp = posi.x.ToString();
        yp = posi.y.ToString();
        
       
        StartCoroutine("Access");
    
    
    
    
    }

    private IEnumerator Access()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("posx", xp);
        dic.Add("posy", yp);

        StartCoroutine(Post("http://localhost/dbaccess/selecttest3.php", dic));
      

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



    

