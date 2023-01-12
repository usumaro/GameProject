using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess3 : MonoBehaviour
{
    GameObject Ghost;
    GameObject Player;

    float xp = 0f;
    float yp = 0f;

    public void Start()
    {

        Player = GameObject.Find("Player");
        Ghost = GameObject.Find("Ghost");
        
      

        

        
      
    }

    public void Update()
    {
        Vector3 posi = Player.transform.position;
        xp = posi.x;
        yp = posi.y;
        
       
        StartCoroutine("Access");
    
    
    
    
    }

    private IEnumerator Access()
    {
        Dictionary<string, float> dic = new Dictionary<string, float>();
        dic.Add("posx", xp);
        dic.Add("posy", yp);

        StartCoroutine(Post("http://localhost/dbaccess/selecttest3.php", dic));
      

        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, float> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, float> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

        }


    }



}



    

